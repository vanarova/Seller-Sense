//TODO: Logging,Make log dir inside project dir, Export log to a specified location(Downloads), if user want to share logs..
//TODO : IDEA: Like logs, we can also export, usage behaviour data in text format.
//TODO: Make a help screen,include help text (Hindi & english) + links to you tube explaining workings
//TODO: Create Check.cs file, add all static code checks


//General notes:
// All forms use a VM_ class, this handles all events and logic for form, why this is used, instaed of code behind class.
// 1. VM_ class is not only for form but, it handles full form tree, with all user controls inside form. All events are handled in one class
// this also helps in sharing data between user controls, as all variables are available in same class, no parent child issue.
// 2. This de-couples form design completely, and form tree including all user and custom controls can be changed/replaced any time, even
// whole form can be kept in another project/dll for re-usage

//All forms use a M_ class, which acts as a Model, for all data related operations.
