using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace IdoRevitTools
{
    class IdoTabExternalApplication : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            try
            {
                string tabName = "Ido Tab";
                string path = Assembly.GetExecutingAssembly().Location;

                application.CreateRibbonTab(tabName);

                // Model Management Panel
                Autodesk.Revit.UI.RibbonPanel modelManagementPanel = application.CreateRibbonPanel(tabName, "Model Management");

                PushButtonData wallCleanupData = new PushButtonData("wallCleanup", "Wall Cleanup", path, "IdoRevitTools.WallCleanupCommand");
                PushButton wallCleanupButton = modelManagementPanel.AddItem(wallCleanupData) as PushButton;
                wallCleanupButton.LargeImage = SvgImageSource("IdoRevitTools.Resources.wall-cleanup.svg");

                PushButtonData modelCheckerData = new PushButtonData("modelChecker", "Model Validator", path, "IdoRevitTools.ModelCheckerCommand");
                PushButton modelCheckerButton = modelManagementPanel.AddItem(modelCheckerData) as PushButton;
                modelCheckerButton.LargeImage = SvgImageSource("IdoRevitTools.Resources.model-checker.svg");

                PushButtonData qualityAssuranceData = new PushButtonData("qualityAssurance", "Quality" + Environment.NewLine + "Assurance", path, "IdoRevitTools.QualityAssuranceCommand");
                PushButton qualityAssuranceButton = modelManagementPanel.AddItem(qualityAssuranceData) as PushButton;
                qualityAssuranceButton.LargeImage = SvgImageSource("IdoRevitTools.Resources.quality-assurance.svg");

                // Documentation Panel
                Autodesk.Revit.UI.RibbonPanel documentationPanel = application.CreateRibbonPanel(tabName, "Documentation");

                PushButtonData roomTaggingData = new PushButtonData("roomTagging", "Room Tagging", path, "IdoRevitTools.RoomTaggingCommand");
                PushButton roomTaggingButton = documentationPanel.AddItem(roomTaggingData) as PushButton;
                roomTaggingButton.LargeImage = SvgImageSource("IdoRevitTools.Resources.room-tagging.svg");

                PushButtonData sheetCreationData = new PushButtonData("sheetCreation", "Sheet Creation", path, "IdoRevitTools.SheetCreationCommand");
                PushButton sheetCreationButton = documentationPanel.AddItem(sheetCreationData) as PushButton;
                sheetCreationButton.LargeImage = SvgImageSource("IdoRevitTools.Resources.sheet-creation.svg");

                PushButtonData detailComponentsData = new PushButtonData("detailComponents", "Detail" + Environment.NewLine + "Components", path, "IdoRevitTools.DetailComponentsCommand");
                PushButton detailComponentsButton = documentationPanel.AddItem(detailComponentsData) as PushButton;
                detailComponentsButton.LargeImage = SvgImageSource("IdoRevitTools.Resources.detail-components.svg");

                // Standards Panel
                Autodesk.Revit.UI.RibbonPanel standardsPanel = application.CreateRibbonPanel(tabName, "Standards");

                PushButtonData viewTemplatesData = new PushButtonData("viewTemplates", "View Templates", path, "IdoRevitTools.ViewTemplatesCommand");
                PushButton viewTemplatesButton = standardsPanel.AddItem(viewTemplatesData) as PushButton;
                viewTemplatesButton.LargeImage = SvgImageSource("IdoRevitTools.Resources.view-templates.svg");

                PushButtonData dimensionStylesData = new PushButtonData("dimensionStyles", "Dimension" + Environment.NewLine + "Styles", path, "IdoRevitTools.DimensionStylesCommand");
                PushButton dimensionStylesButton = standardsPanel.AddItem(dimensionStylesData) as PushButton;
                dimensionStylesButton.LargeImage = SvgImageSource("IdoRevitTools.Resources.dimension-styles.svg");

                PushButtonData textStandardizationData = new PushButtonData("textStandardization", "Text" + Environment.NewLine + "Standardization", path, "IdoRevitTools.TextStandardizationCommand");
                PushButton textStandardizationButton = standardsPanel.AddItem(textStandardizationData) as PushButton;
                textStandardizationButton.LargeImage = SvgImageSource("IdoRevitTools.Resources.text-standardization.svg");

                // Data Management Panel
                Autodesk.Revit.UI.RibbonPanel dataManagementPanel = application.CreateRibbonPanel(tabName, "Data Management");

                PushButtonData scheduleExportData = new PushButtonData("scheduleExport", "Schedule Export", path, "IdoRevitTools.ScheduleExportCommand");
                PushButton scheduleExportButton = dataManagementPanel.AddItem(scheduleExportData) as PushButton;
                scheduleExportButton.LargeImage = SvgImageSource("IdoRevitTools.Resources.schedule-export.svg");

                PushButtonData parameterManagerData = new PushButtonData("parameterManager", "Parameter" + Environment.NewLine + "Manager", path, "IdoRevitTools.ParameterManagerCommand");
                PushButton parameterManagerButton = dataManagementPanel.AddItem(parameterManagerData) as PushButton;
                parameterManagerButton.LargeImage = SvgImageSource("IdoRevitTools.Resources.parameter-manager.svg");

                PushButtonData familyManagerData = new PushButtonData("familyManager", "Family Manager", path, "IdoRevitTools.FamilyManagerCommand");
                PushButton familyManagerButton = dataManagementPanel.AddItem(familyManagerData) as PushButton;
                familyManagerButton.LargeImage = SvgImageSource("IdoRevitTools.Resources.family-manager.svg");

                // Coordination Panel
                Autodesk.Revit.UI.RibbonPanel coordinationPanel = application.CreateRibbonPanel(tabName, "Coordination");

                PushButtonData linkManagementData = new PushButtonData("linkManagement", "Link Management", path, "IdoRevitTools.LinkManagementCommand");
                PushButton linkManagementButton = coordinationPanel.AddItem(linkManagementData) as PushButton;
                linkManagementButton.LargeImage = SvgImageSource("IdoRevitTools.Resources.link-management.svg");

                PushButtonData coordinationReviewData = new PushButtonData("coordinationReview", "Coordination" + Environment.NewLine + "Review", path, "IdoRevitTools.CoordinationReviewCommand");
                PushButton coordinationReviewButton = coordinationPanel.AddItem(coordinationReviewData) as PushButton;
                coordinationReviewButton.LargeImage = SvgImageSource("IdoRevitTools.Resources.coordination-review.svg");

                // Automation Panel
                Autodesk.Revit.UI.RibbonPanel automationPanel = application.CreateRibbonPanel(tabName, "Automation");

                PushButtonData batchProcessingData = new PushButtonData("batchProcessing", "Batch" + Environment.NewLine + "Processing", path, "IdoRevitTools.BatchProcessingCommand");
                PushButton batchProcessingButton = automationPanel.AddItem(batchProcessingData) as PushButton;
                batchProcessingButton.LargeImage = SvgImageSource("IdoRevitTools.Resources.batch-processing.svg");

                // Utilities Panel
                Autodesk.Revit.UI.RibbonPanel utilitiesPanel = application.CreateRibbonPanel(tabName, "Utilities");

                PushButtonData elementPurgeData = new PushButtonData("elementPurge", "Element Purge", path, "IdoRevitTools.ElementPurgeCommand");
                PushButton elementPurgeButton = utilitiesPanel.AddItem(elementPurgeData) as PushButton;
                elementPurgeButton.LargeImage = SvgImageSource("IdoRevitTools.Resources.element-purge.svg");

                PushButtonData worksetManagerData = new PushButtonData("worksetManager", "Workset" + Environment.NewLine + "Manager", path, "IdoRevitTools.WorksetManagerCommand");
                PushButton worksetManagerButton = utilitiesPanel.AddItem(worksetManagerData) as PushButton;
                worksetManagerButton.LargeImage = SvgImageSource("IdoRevitTools.Resources.workset-manager.svg");

                PushButtonData clashDetectionData = new PushButtonData("clashDetection", "Clash Detection", path, "IdoRevitTools.ClashDetectionCommand");
                PushButton clashDetectionButton = utilitiesPanel.AddItem(clashDetectionData) as PushButton;
                clashDetectionButton.LargeImage = SvgImageSource("IdoRevitTools.Resources.clash-detection.svg");

                // Pin Tools Panel
                Autodesk.Revit.UI.RibbonPanel pinToolsPanel = application.CreateRibbonPanel(tabName, "Pin Tools");

                PushButtonData pinManualData = new PushButtonData("pinManual", "Manual", path, "IdoRevitTools.PinManualCommand");
                pinManualData.Image = SvgImageSource("IdoRevitTools.Resources.pin-manual.svg");

                PushButtonData pinSelectionData = new PushButtonData("pinSelection", "Selection", path, "IdoRevitTools.PinSelectionCommand");
                pinSelectionData.Image = SvgImageSource("IdoRevitTools.Resources.pin-selection.svg");

                PushButtonData pinAutomaticData = new PushButtonData("pinAutomatic", "Automatic", path, "IdoRevitTools.PinAutomaticCommand");
                pinAutomaticData.Image = SvgImageSource("IdoRevitTools.Resources.pin-automatic.svg");

                SplitButtonData pinSplitButtonData = new SplitButtonData("pinSplitButton", "Pin Tools");
                SplitButton pinSplitButton = pinToolsPanel.AddItem(pinSplitButtonData) as SplitButton;
                pinSplitButton.AddPushButton(pinManualData);
                pinSplitButton.AddPushButton(pinSelectionData);
                pinSplitButton.AddPushButton(pinAutomaticData);

                return Result.Succeeded;
            }
            catch (Exception e)
            {
                TaskDialog.Show("Error", "Fail to load Ido Tools plugin\n Error- " + e.Message);
                return Result.Failed;
            }
        }

        private System.Windows.Media.ImageSource SvgImageSource(string embeddedPath)
        {
            Stream stream = this.GetType().Assembly.GetManifestResourceStream(embeddedPath);
            var decoder = new System.Windows.Media.Imaging.PngBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            return decoder.Frames[0];
        }
    }
}