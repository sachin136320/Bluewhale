using System;
using aptmgt.entity.intfc;

namespace aptmgt.entity.impl
{
    public class BaseUser : IUser
    {
        public BaseUser()
        {
            _name = "Subodh";
            _phone = "9901123456";
        }
        private string _name;
        public string Name { get => _name; set => _name = value; }

        private string _phone;
        public string Phone { get => _phone; set => _phone = value; }
         

    }
}
