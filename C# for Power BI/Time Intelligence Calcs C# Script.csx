// This script will apply Time Intelligence functions to the selected measures

// The first section calculates values for specific periods

// The second section makes period-over-period calculations

// First Section

var dateColumn = "'OnPremDW_VW_Dim_Date'[ActualDate]"; //R&L Actual Date Column from Date table

foreach(var m in Selected.Measures)
{
    // Current Year:
    m.Table.AddMeasure(
        "CY " + m.Name, // Measure Name
        "CALCULATE(" + m.DaxObjectName + ", YEAR(" + dateColumn + ") = YEAR(MAX("+dateColumn+")))", // DAX Expression
        m.DisplayFolder
    );

    // Current Month:
    m.Table.AddMeasure(
        "CM " + m.Name, // Measure Name
        "CALCULATE(" + m.DaxObjectName + ", YEAR(" + dateColumn + ") = YEAR(MAX("+dateColumn+")), MONTH(" + dateColumn + ") = MONTH(MAX("+dateColumn+")))", // DAX Expression
        m.DisplayFolder
    );


    // Previous Year:
    m.Table.AddMeasure(
        "PY " + m.Name, // Measure Name
        "CALCULATE(" + m.DaxObjectName + ", SAMEPERIODLASTYEAR(" + dateColumn + "))", // DAX Expression
        m.DisplayFolder
    );


    // Previous Month:
    m.Table.AddMeasure(
        "PM " + m.Name, // Measure Name
        "CALCULATE(" + m.DaxObjectName + ", DATEADD(" + dateColumn + ", -1, MONTH))", // DAX Expression
        m.DisplayFolder
    );


//Second Section


    // YoY Difference:
    m.Table.AddMeasure(
        "YoY Difference " + m.Name, // Measure Name
        m.DaxObjectName + "- [PY " + m.Name + "]", // DAX Expression
        m.DisplayFolder
    );

    
    // YoY pct. change:
    m.Table.AddMeasure(
        "YoY Pct. Change " + m.Name, // Measure Name
        "DIVIDE([YoY Difference " + m.Name + "], [PY " + m.Name + "])", // DAX Expression
        m.DisplayFolder
    );


     // MoM Difference:
    m.Table.AddMeasure(
        "MoM Difference " + m.Name, // Measure Name
        "[CM " + m.Name + "] - [PM " + m.Name + "]", // DAX Expression
        m.DisplayFolder
    );

    
    // MoM pct. change:
    m.Table.AddMeasure(
        "MoM Pct. Change " + m.Name, // Measure Name
        "DIVIDE([MoM Difference " + m.Name + "], [PM " + m.Name + "])", // DAX Expression
        m.DisplayFolder
    );
}
