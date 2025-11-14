using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register
{
    public interface IRegisterCallback
    {
        void OnRegistered(string username);
        void OnBackToLogin(); // thêm để xử lý nút "Back"
    }
}
