using System;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MonkeyInCloud.Core
{
	public class MonkeyInCloudService : IMonkeyInCloudService
	{
		private MobileServiceClient _mobileServiceClient;

		public MonkeyInCloudService ()
		{
			_mobileServiceClient = new MobileServiceClient("", "");
		}

		public async Task<ObservableCollection<Monkey>> GiveMeTheMoneys()
		{
			var monkeys = new ObservableCollection<Monkey> ();

			try {

				var table = _mobileServiceClient.GetTable<Monkey>();
				monkeys = await table.ToCollectionAsync<Monkey>();

			} catch (Exception ex) {
				throw ex;
			}

			return monkeys;
		}

		public async Task NewMonkeyInTwon(Monkey monkey)
		{
			try {

				var table = _mobileServiceClient.GetTable<Monkey>();
				await table.InsertAsync(monkey);
				
			} catch (Exception ex) {
				throw ex;
			}
		}

		public async Task NewMonkeysInTwon (ObservableCollection<Monkey> monkeys)
		{
			try {
				
				foreach (var monkey in monkeys) {
					await NewMonkeyInTwon(monkey);	
				}
					
			} catch (Exception ex) {
				throw ex;
			}
		}
	}
}

