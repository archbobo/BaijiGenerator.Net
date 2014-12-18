using CTripOSS.Baiji.IDLParser.Model;

namespace CTripOSS.Baiji.Generator
{
    public class CodeType
    {
        private readonly string _idlNamespace;
        private readonly string _name;
        private readonly string _idlName;
        private readonly string _codeNamespace;

        public CodeType(string idlNamespace, string idlName, string name, string codeNamespace, Definition definition)
        {
            _idlNamespace = idlNamespace;
            _idlName = idlName;
            _name = name;
            _codeNamespace = codeNamespace;
            IsStruct = false;
            IsEnum = false;
            Definition = definition;
        }

        public Definition Definition
        {
            get;
            set;
        }

        public bool IsStruct
        {
            get;
            set;
        }

        public bool IsEnum
        {
            get;
            set;
        }

        public string CodeNamespace
        {
            get
            {
                return _codeNamespace;
            }
        }

        public string IdlNamespace
        {
            get
            {
                return _idlNamespace;
            }
        }

        public string IDLName
        {
            get
            {
                return _idlName;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string FullName
        {
            get
            {
                return _codeNamespace + "." + _name;
            }
        }

        public string Key
        {
            get
            {
                return _idlNamespace + "." + _idlName;
            }
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (CodeType)obj;
            if (_codeNamespace == null)
            {
                if (other._codeNamespace != null)
                {
                    return false;
                }
            }
            else if (_codeNamespace != other._codeNamespace)
            {
                return false;
            }

            if (_name == null)
            {
                if (other._name != null)
                {
                    return false;
                }
            }
            else if (_name != other._name)
            {
                return false;
            }

            if (_idlNamespace == null)
            {
                if (other._idlNamespace != null)
                {
                    return false;
                }
            }
            else if (_idlNamespace != other._idlNamespace)
            {
                return false;
            }

            if (_idlName == null)
            {
                if (other._idlName != null)
                {
                    return false;
                }
            }
            else if (_idlName != other._idlName) 
            {
                return false;
            }

            if (IsStruct != other.IsStruct)
            {
                return false;
            }
            if (IsEnum != other.IsEnum)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            int result = 1;
            result = prime * result + ((_codeNamespace == null) ? 0 : _codeNamespace.GetHashCode());
            result = prime * result + ((_name == null) ? 0 : _name.GetHashCode());
            result = prime * result + ((_idlNamespace == null) ? 0 : _idlNamespace.GetHashCode());
            result = prime * result + ((_idlName == null) ? 0 : _idlName.GetHashCode());
            return result;
        }

        public override string ToString()
        {
            return string.Format("[Baiji namespace = {0}, Baiji name = {1}, name = {2}, namespace = {3}]", _idlNamespace, _idlName, _name,
                _codeNamespace);
        }
    }
}