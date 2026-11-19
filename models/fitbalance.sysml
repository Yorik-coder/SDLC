package FitBalanceUI {
  part mainWindow;

  part profileInputPanel;

  part trainingProgramPanel;

  part calculationPanel;

  part nutritionDataGrid;
}

// Relationships
connect mainWindow to profileInputPanel;
connect mainWindow to trainingProgramPanel;
connect mainWindow to calculationPanel;
connect mainWindow to nutritionDataGrid;

// Element overrides
// @pos "FitBalanceUI::mainWindow" 800,100
// @pos "FitBalanceUI::profileInputPanel" 720,250
// @pos "FitBalanceUI::trainingProgramPanel" 920,250
// @pos "FitBalanceUI::calculationPanel" 1120,240
// @pos "FitBalanceUI::nutritionDataGrid" 520,250
// @pos "FitBalanceUI" 490,30