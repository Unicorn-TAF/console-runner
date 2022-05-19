﻿using System.Collections.Generic;
using Unicorn.Toolbox.Analysis;
using Unicorn.Toolbox.LaunchAnalysis;

namespace Unicorn.Toolbox.ViewModels
{
    public class DialogHostViewModel : ViewModelBase
    {
        public DialogHostViewModel(Dictionary<string, IEnumerable<TestResult>> data)
        {
            CurrentViewModel = new FailedTestsViewModel(data);
            OnCurrentViewModelChanged();
        }

        public DialogHostViewModel(List<TestInfo> data)
        {
            CurrentViewModel = new TestPreviewViewModel(data);
            OnCurrentViewModelChanged();
        }

        public ViewModelBase CurrentViewModel { get; set; }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
