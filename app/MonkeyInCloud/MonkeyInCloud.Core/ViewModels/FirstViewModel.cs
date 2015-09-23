using Cirrious.MvvmCross.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MonkeyInCloud.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {

		private MonkeyInCloudService _monkeyInClodService;

		#region Monkeys 
		private ObservableCollection<Monkey> _monkeys;

		public ObservableCollection<Monkey> Monkeys
		{
			get { return _monkeys; }
			set { if(_monkeys != value) { 
					_monkeys = value;
					RaisePropertyChanged (() => Monkeys);
				} 
			}
		}

		public void AddSomeMonkeys()
		{
			var monkeys = new ObservableCollection<Monkey> { 
			
				new Monkey { Name = "William S. Rodriguez", TwitterHandle = "@WilliamSRodz", PhotoUrl = "https://avatars3.githubusercontent.com/u/374777?v=3&s=460" }, 
			
			};

			_monkeyInClodService.NewMonkeysInTwon (monkeys);
		}

		public async Task LoadSomeMonkeys()
		{
			Monkeys = await _monkeyInClodService.GiveMeTheMoneys();

			if (_monkeys == null || Monkeys.Count == 0) {
				AddSomeMonkeys (); // demo
				Monkeys = await _monkeyInClodService.GiveMeTheMoneys(); // again
			}
		}

		#endregion


		private string _hello = "Hello MvvmCross";
        public string Hello
		{ 
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged(() => Hello); }
		}
    }
}
