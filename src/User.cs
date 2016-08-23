using System;
using System.Text;

namespace tsign2
{
    public class User
    {
        private enum States { Lastname, LastnameLower, LastnameUpper, FirstNameSeparator, FirstNameIndex, FirstName, MiddleNameSeparator, End };

        public string Lastname;
        public string Fullname;

        public User(string rawname)
        {
            ParseRawName(rawname);
        }

        private void ParseRawName(string rawname)
        {
            var upper = rawname.ToUpper();
            var lower = rawname.ToLower();

            int indexFirstName = 0;
            int indexMiddleName = 0;

            int i = 1;
            int len = rawname.Length;
            var state = States.Lastname;

            var name = new StringBuilder(rawname.Length + 3);
            name.Append(upper[0]);

            while (i < len && state != States.End) {
                switch (state) {
                    case States.Lastname:
                        if (lower[i] == upper[i]) {
                            state = States.FirstNameSeparator;
                        } else if (rawname[i] == upper[i]) {
                            state = States.LastnameUpper;
                        } else {
                            state = States.LastnameLower;
                        }
                        break;
                    case States.LastnameLower:
                        if (lower[i] == upper[i]) {
                            state = States.FirstNameSeparator;
                        } else if (rawname[i] == upper[i]) {
                            state = States.FirstNameIndex;
                        } else {
                            name.Append(lower[i]);
                            i++;
                        }
                        break;
                    case States.LastnameUpper:
                        if (lower[i] == upper[i]) {
                            state = States.FirstNameSeparator;
                        } else {
                            name.Append(lower[i]);
                            i++;
                        }
                        break;
                    case States.FirstNameSeparator:
                        if (lower[i] != upper[i]) {
                            state = States.FirstNameIndex;
                        } else {
                            i++;
                        }
                        break;
                    case States.FirstNameIndex:
                        indexFirstName = i;
                        state = States.FirstName;
                        i++;
                        break;
                    case States.FirstName:
                        if (lower[i] == upper[i]) {
                            state = States.MiddleNameSeparator;
                            break;
                        }
                        if (rawname[i] == upper[i]) {
                            if (indexMiddleName == 0) {
                                indexMiddleName = i;
                            } else {
                                indexMiddleName = -1;
                            }
                        }
                        i++;
                        break;
                    case States.MiddleNameSeparator:
                        if (lower[i] != upper[i]) {
                            indexMiddleName = i;
                            state = States.End;
                        } else {
                            i++;
                        }
                        break;
                }
            }

            Lastname = name.ToString();
            if (indexFirstName > 0) {
                name.Append(' ');
                name.Append(upper[indexFirstName]);
                name.Append('.');
                if (indexMiddleName > 0) {
                    name.Append(upper[indexMiddleName]);
                    name.Append('.');
                }
            }
            Fullname = name.ToString();
        }

        public override string ToString()
        {
            return Fullname;
        }
    }
}
