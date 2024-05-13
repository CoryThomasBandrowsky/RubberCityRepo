using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubberCity.Services.Services
{
    public class DashboardService
    {
        private readonly HelpRequestService _helpRequestService;
        private readonly UserMessageService _userMessageService;
        private readonly UserService _userService;
        private readonly CaseService _caseService;

        public DashboardService(HelpRequestService helpRequestService,
                                UserMessageService userMessageService,
                                UserService userService,
                                CaseService caseService)
        {
            _helpRequestService = helpRequestService;
            _userMessageService = userMessageService;
            _userService = userService;
            _caseService = caseService;
        }

        public async Task<List<DashboardResult>> GetAllDashboardResults(string userId)
        {
            var user = await _userService.GetByIdAsync(int.Parse(userId));
            var activeCases = await _caseService.GetAllActiveAsync();
            var caseList = activeCases.ToList();
            var results = await CreateDashboardResults(caseList, user);
            return results;
        }

        private async Task<List<DashboardResult>> CreateDashboardResults(List<Case> cases, User user)
        {
            var dashboardResults = new List<DashboardResult>();

            foreach (var c in cases)
            {
                var entry = new DashboardResult();

                var helpRequest = await _helpRequestService.GetByIdAsync(c.HelpRequestID);

                entry.Summary = c.Summary;
                entry.FirstName = helpRequest.FirstName;
                entry.LastName = helpRequest.LastName;
                entry.DateCreated = c.DateCreated;
                entry.UserID = user.ID;

                dashboardResults.Add(entry);
            }

            return dashboardResults;
        }
    }
}
