using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification
{
    internal class Notificationc
    {
        public int Count { get; set; } = 0;
        public string NotificationContent { get; set; }

        public void Show()
        {
            Console.WriteLine(NotificationContent);
        }
    }
}
