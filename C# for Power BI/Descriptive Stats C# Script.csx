// This script gets descriptive statistics for the selected columns


// Sum values in selected column
 
foreach( var col in Selected.Columns)
{
    col.Table.AddMeasure(
        "Total " + col.Name, // Name of measure
        "SUM("+ col.DaxObjectFullName + ")",
        col.DisplayFolder
    );

// Max value in selected column

    col.Table.AddMeasure(
        "Max " + col.Name, // Name of measure
        "MAX("+ col.DaxObjectFullName + ")",
        col.DisplayFolder
    );

// Min value in selected column
 
    col.Table.AddMeasure(
        "Min " + col.Name, // Name of measure
        "MIN("+ col.DaxObjectFullName + ")",
        col.DisplayFolder
    );

// Average value in selected column
 
    col.Table.AddMeasure(
        "Average " + col.Name, // Name of measure
        "AVERAGE("+ col.DaxObjectFullName + ")",
        col.DisplayFolder
    );

// Median value in selected column
 
    col.Table.AddMeasure(
        "Median " + col.Name, // Name of measure
        "Median("+ col.DaxObjectFullName + ")",
        col.DisplayFolder
    );

}
 