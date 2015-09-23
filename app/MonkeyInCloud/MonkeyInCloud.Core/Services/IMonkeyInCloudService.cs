using System;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MonkeyInCloud.Core
{
	public interface IMonkeyInCloudService
	{
		Task<ObservableCollection<Monkey>> GiveMeTheMoneys();

		Task NewMonkeyInTwon(Monkey monkey);

		Task NewMonkeysInTwon(ObservableCollection<Monkey>  monkeys);
	}
}

