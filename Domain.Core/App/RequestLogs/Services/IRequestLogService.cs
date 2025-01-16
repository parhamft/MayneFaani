using Domain.Core.App.RequestLogs.Data;
using Domain.Core.App.Requests.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.App.RequestLogs.Services
{
    public interface IRequestLogService
    {
        public bool AddRequestLog(Request request);
    }
}
