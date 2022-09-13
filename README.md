Fabulous.WPF
=======

*F# Functional App Development for WPF, using declarative dynamic UI*

This is just a Proof of Concept of making an F# MVU framework for WPF using Fabulous and Fabulous.CodeGen.

![sample](https://user-images.githubusercontent.com/6429007/67047753-3a954d00-f133-11e9-88ca-10c2d7a370f1.gif)

https://github.com/fsprojects/Fabulous

# Sudoku Sample

Sudoku Sample contains two projects, the original C# version and F# version with Fabulous.WPF. The purpose of the Sudoku sample is to test advanced WPF features and how they can be ported to Fabuous.WPF. Advanced features in this sample:
1. Hierarchial MVU modelling, i.e. high level MVU architecture contain building block that are created with MVU using Fabulous.WPF.In this case, the Board (see the image) is on the top level MVU. Region is on the next level and finally tile is in the lowest level.
2. Attached behaviours so that we can implement functionality that can not be achieved by standard MVU (or MVVM in the C# version of the sample)

![Sudoku terminology](samples/Sudoku.CS/Sudoku%20domain%20model.png)