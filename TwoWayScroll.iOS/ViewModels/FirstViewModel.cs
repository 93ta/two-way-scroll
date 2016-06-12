using System;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace TwoWayScroll.iOS.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        public FirstViewModel()
        {
            _numbers = PopulateData();
            _allNumbers = _numbers.Select(i => new NumberViewModel(i)).ToList();
            _allGroups = MakeGroups(_allNumbers);
        }

        List<int> PopulateData()
        {
            var data = new List<int>();
            for (int i = 0; i < 100; i++) data.Add(i);
            return data;
        }

        List<NumberGroupViewModel> MakeGroups(List<NumberViewModel> numVms)
        {
            var groupVms = new List<NumberGroupViewModel>();
            var groups = numVms.GroupBy(g => g.GroupKey);

            foreach (var group in groups)
            {
                var groupNumVms = new List<NumberViewModel>();
                groupNumVms.AddRange(group);
                groupVms.Add(new NumberGroupViewModel {GroupKey = group.Key, NumberVms = groupNumVms});
            }

            return groupVms;
        }

        private List<int> _numbers;
        public List<int> Numbers
        {
            get { return _numbers; }
            set 
            {
                _numbers = value;
                RaisePropertyChanged(nameof(Numbers));
            }
        }

        private List<NumberViewModel> _allNumbers;
        public List<NumberViewModel> AllNumbers
        {
            get { return _allNumbers; }
            set 
            {
                _allNumbers = value;
                RaisePropertyChanged(nameof(AllNumbers));
            }
        }

        private List<NumberGroupViewModel> _allGroups;
        public List<NumberGroupViewModel> AllGroups
        {
            get { return _allGroups; }
            set
            {
                _allGroups = value;
                RaisePropertyChanged(nameof(AllGroups));
            }
        }
    }

    public class NumberViewModel : MvxViewModel
    {
        public NumberViewModel(int num)
        {
            _number = num;
            _groupKey = num % 10;
        }

        private int _groupKey;
        public int GroupKey
        {
            get { return _groupKey; }
            set
            {
                _groupKey = value;
                RaisePropertyChanged(nameof(GroupKey));
            } 
        }

        private int _number;
        public int Number
        {
            get { return _number;}
            set 
            {
                _number = value;
                RaisePropertyChanged(nameof(Number));
            }
        }

        public void CountUp() {
            Number++;
        }

        private IMvxCommand _buttonCommand;
        public IMvxCommand ButtonCommand
        {
            get
            {
                _buttonCommand = _buttonCommand ?? new MvxCommand(() => CountUp());
                return _buttonCommand;
            }
        }
    }

    public class NumberGroupViewModel : MvxViewModel
    {
        public NumberGroupViewModel()
        {
        }

        private int _groupKey;
        public int GroupKey
        {
            get { return _groupKey; }
            set
            {
                _groupKey = value;
                RaisePropertyChanged(nameof(GroupKey));
            }
        }

        private List<NumberViewModel> _numberVms;
        public List<NumberViewModel> NumberVms
        {
            get { return _numberVms; }
            set 
            {
                _numberVms = value;
                RaisePropertyChanged(nameof(NumberVms));
            }
        }
    }
}

