﻿using System.Collections.Generic;
using System.Windows;
using Unicorn.Toolbox.LaunchAnalysis;
using Unicorn.Toolbox.ViewModels;
using Unicorn.Toolbox.Visualization;

namespace Unicorn.Toolbox.Commands
{
    public class VisualizeCommand : CommandBase
    {
        private readonly VisualizationViewModel _viewModel;

        public VisualizeCommand(VisualizationViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (_viewModel.CurrentViewModel is StatisticsViewModel stats)
            {
                VisualizeStatistics(stats);
            } 
            else if (_viewModel.CurrentViewModel is CoverageViewModel coverage)
            {
                VisualizeCoverage(coverage);
            }
            else
            {
                VisualizeResults(_viewModel.CurrentViewModel as LaunchResultsViewModel);
            }
        }

        private void VisualizeStatistics(StatisticsViewModel stats)
        {
            WindowVisualization visualization = GetVisualizationWindow($"Overall tests statistics: {stats.CurrentFilter}");

            var data = stats.GetVisualizationData();

            if (_viewModel.Circles)
            {
                new VisualizerCircles(visualization.canvasVisualization, _viewModel.CurrentPalette)
                    .VisualizeData(data);
            }
            else
            {
                new VisualizerBars(visualization.canvasVisualization, _viewModel.CurrentPalette)
                    .VisualizeData(data);

                visualization.InjectExportToVisualization();
            }
        }

        private void VisualizeCoverage(CoverageViewModel coverage)
        {
            WindowVisualization visualization = GetVisualizationWindow("Modules coverage by tests");

            var vizData = coverage.GetVisualizationData();

            if (_viewModel.Circles)
            {
                new VisualizerCircles(visualization.canvasVisualization, _viewModel.CurrentPalette)
                    .VisualizeData(vizData);
            }
            else
            {
                new VisualizerBars(visualization.canvasVisualization, _viewModel.CurrentPalette)
                    .VisualizeData(vizData);

                visualization.InjectExportToVisualization();
            }
        }

        private void VisualizeResults(LaunchResultsViewModel launchResults)
        {
            var visualization = GetVisualizationWindow("Launch visualization");

            new LaunchVisualizer(visualization.canvasVisualization, launchResults.ExecutionsList.SourceCollection as List<Execution>)
                .Visualize();
        }

        private WindowVisualization GetVisualizationWindow(string title)
        {
            var visualization = new WindowVisualization
            {
                Title = title
            };

            if (_viewModel.Fullscreen)
            {
                visualization.WindowState = WindowState.Maximized;
            }
            else
            {
                visualization.ShowActivated = false;
            }

            visualization.Show();

            return visualization;
        }
    }
}
