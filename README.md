Fabulous.WPF
=======

*F# Functional App Development for WPF, using declarative dynamic UI*

For the time being this is just a Proof of Concept of making an F# MVU framework for WPF using Fabulous and Fabulous.CodeGen.

![sample](https://user-images.githubusercontent.com/6429007/67047753-3a954d00-f133-11e9-88ca-10c2d7a370f1.gif)

https://github.com/fsprojects/Fabulous

# Sudoku Sample

Sudoku Sample contains two projects, the original C# version and F# version with Fabulous.WPF. The purpose of the Sudoku sample is to provide best practises for porting advanced WPF features to Fabulous.WPF. Advanced features in this sample include:
1. Hierarchical MVU modelling, i.e. high level MVU architecture contains building block(s) that are created with MVU using Fabulous.WPF. In this case, the Board (see the image below) is on the top level MVU. Region is on the next level and finally tile is in the lowest level.
2. Attached behaviors so that we can implement functionality that can not be achieved by standard MVU (or MVVM in the C# version of the sample)
3. DataTemplates - how to achieve similar functionality in Fabulous.WPF
4. Resources with x:Key directive
5. Style triggers

The C# version of the Sudoku sample is implemented in traditonal MVVM while F# is ported with same UI functionality, but with Fabulous.WPF patterns

![Sudoku terminology](DocResources/Sudoku%20domain%20model.png)

# Best Practises And Patterns in Porting WPF MVVM Views to Fabulous.WPF

## Hierarchical MVU modelling

To connect to lower level View of MVU pattern you just simply call the lower level View (`Tiles.view` in the example image) with <model.LowerLevelModel> (`model.Tile` in the example image)

![Hierarchical MVU](DocResources/Hierarchical%20MVU.png)

## Attached Behaviors

Example will be provided later

## Data Templates

Brief instructions welcome

## Resources with x:Key Directive

Brief instructions welcome

## Style Triggers

Brief instructions welcome