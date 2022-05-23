﻿using System.Collections.Generic;
using System.Linq;
using Unicorn.Toolbox.LaunchAnalysis;
using Unicorn.Toolbox.ViewModels;

namespace Unicorn.Toolbox.Commands
{
    public class SearchInExecutedTestsCommand : CommandBase
    {
        private readonly LaunchResultsViewModel _viewModel;
        private LaunchResult _launchResult;

        public SearchInExecutedTestsCommand(
            LaunchResultsViewModel viewModel, 
            LaunchResult launchResult)
        {
            _viewModel = viewModel;
            _launchResult = launchResult;
        }

        public override void Execute(object parameter)
        {
            ExecutedTestsFilter testsFilter = new ExecutedTestsFilter();
            IEnumerable<TestResult> results = _launchResult.Executions.SelectMany(exec => exec.TestResults);

            switch (_viewModel.FilterFailsBy)
            {
                case FailsFilter.ErrorMessage:
                    testsFilter.FilterTestsByFailMessage(results, _viewModel.FailSearchCriteria, false);
                    break;
                case FailsFilter.ErrorMessageRegex:
                    testsFilter.FilterTestsByFailMessage(results, _viewModel.FailSearchCriteria, true);
                    break;
                case FailsFilter.Time:
                    testsFilter.FilterTestsByTime(results, _viewModel.FailSearchCriteria);
                    break;
            }

            _viewModel.Filter = testsFilter;
            _viewModel.UpdateFilteredTestsCount();
        }
    }
}
