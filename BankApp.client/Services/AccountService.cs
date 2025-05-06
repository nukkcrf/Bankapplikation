using BankApp.Client.Models;
using BankApp.Client.DTOs;
using System.Net.Http.Json;


namespace BankApp.Client.Services
{
    public class AccountService
    {
        private readonly HttpClient _http;

        public AccountService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Account>> GetAccountsAsync()
        {
            return await _http.GetFromJsonAsync<List<Account>>("api/accounts");
        }

        public async Task DepositAsync(int accountId, decimal amount)
        {
            var request = new AmountRequest { Amount = amount };
            await _http.PostAsJsonAsync($"api/accounts/{accountId}/deposit", request);
        }

        public async Task WithdrawAsync(int accountId, decimal amount)
        {
            var request = new AmountRequest { Amount = amount };
            await _http.PostAsJsonAsync($"api/accounts/{accountId}/withdraw", request);
        }

        public async Task TransferAsync(int fromId, int toId, decimal amount)
        {
            var request = new TransferRequest
            {
                FromAccountId = fromId,
                ToAccountId = toId,
                Amount = amount
            };

            await _http.PostAsJsonAsync("api/accounts/transfer", request);
        }

        public async Task<List<Transaction>> GetTransactionsAsync()
        {
            return await _http.GetFromJsonAsync<List<Transaction>>("api/transactions");
        }
    }
}
