﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Unicorn.Toolbox.Analysis;
using Unicorn.Toolbox.Commands;
using Unicorn.Toolbox.Coverage;

namespace Unicorn.Toolbox.ViewModels
{
    public class CoverageViewModel : ViewModelBase
    {
        private readonly SpecsCoverage _coverage;
        private readonly Analyzer _analyzer;
        private readonly MainWindow _window;
        private bool canGetCoverage;
        private IEnumerable<Module> modulesList;

        public CoverageViewModel(Analyzer analyzer)
        {
            _window = App.Current.MainWindow as MainWindow;
            _coverage = new SpecsCoverage();
            _analyzer = analyzer;

            LoadSpecsCommand = new LoadSpecsCommand(this, _coverage);
            GetCoverageCommand = new GetCoverageCommand(this, _coverage, _analyzer);
        }

        public ICommand LoadSpecsCommand { get; }

        public ICommand GetCoverageCommand { get; }

        public bool CanGetCoverage
        {
            get => canGetCoverage;

            set
            {
                canGetCoverage = value;
                OnPropertyChanged(nameof(CanGetCoverage));
            }
        }

        public IEnumerable<Module> ModulesList
        {
            get => modulesList;

            set
            {
                modulesList = value;
                OnPropertyChanged(nameof(ModulesList));
            }
        }

        public void UpdateModel()
        {
            UiUtils.FillGrid(_window.CoverageView.gridModules, new HashSet<string>(_coverage.Specs.Modules.Select(m => m.Name)));

            foreach (var checkbox in _window.CoverageView.gridModules.Children)
            {
                ((CheckBox)checkbox).IsChecked = false;
                ((CheckBox)checkbox).Checked += new RoutedEventHandler(UpdateRunTagsText);
                ((CheckBox)checkbox).Unchecked += new RoutedEventHandler(UpdateRunTagsText);
            }

            CanGetCoverage = _analyzer.Data != null;

            if (CanGetCoverage)
            {
                GetCoverageCommand.Execute(null);
            }
        }

        private void UpdateRunTagsText(object sender, RoutedEventArgs e)
        {
            var runTags = new HashSet<string>();

            foreach (var child in _window.CoverageView.gridModules.Children)
            {
                var checkbox = child as CheckBox;

                if (checkbox.IsChecked.Value)
                {
                    runTags.UnionWith(_coverage.Specs.Modules
                        .First(m => m.Name.Equals(checkbox.Content.ToString(), StringComparison.InvariantCultureIgnoreCase))
                        .Features);
                }
            }

            _window.CoverageView.textBoxRunTags.Text = "#" + string.Join(" #", runTags);
        }

        public IOrderedEnumerable<KeyValuePair<string, int>> GetVisualizationData()
        {
            var featuresStats = new Dictionary<string, int>();

            foreach (var module in _coverage.Specs.Modules)
            {
                var tests = from SuiteInfo s
                            in module.Suites
                            select s.TestsInfos;

                featuresStats.Add(module.Name, tests.Sum(t => t.Count));
            }

            var items = from pair in featuresStats
                        orderby pair.Value descending
                        select pair;

            return items;
        }
    }
}
