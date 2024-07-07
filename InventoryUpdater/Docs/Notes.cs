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


/// If a product is listed 2x times, Create a prop with duplicate_inHouseCode, this property will contains original product code
/// The inhouse code for duplicate product can be anything, but for sorting reason, make it inhousecode_1 
/// This duplicate product listing can have diff background color
/// when in house inventory updates, it will also add/substract duplicate items

//if (invSnapshotList == default(IList<SellerSense.Model.InvUpdate.InvSnapshotEntry>))
//return;
// use everywhere comparisons like above to check return values from a function.

//in product proprty page add buttons to show big image, disable button with no image.

//In product grid page, add selection col to select and export product images with rates appended in names

// product property page shud close with ESC button

//After searching a product add a feature to export product to telegram.

//Add telegram based logging feature. - done

//Improve loggerm robust logging is needed - done

//make a snapshot comparison form - compare snapshots from diff dates, provide option to compare last day, weekly analysis etc
// in comparr grid, mark with spcecial color, rows where user imported inventory
// make another columns for inv comparison, make checkboxes to show hide, data for 1 company only.

// On mapping screen, snapdeal mapping takes long time,, add a loading control async.


//######
//BUGS ---------------

// while copmparing snapshots, all snapshots must be form same date, if they are not of same date, an warning alert should be shown to user,
//that is is looking into wrong data, and he should download all snapshots every day.


// Inv updation is having issues, same product - cactus , when updated on HE, is not updated at CC. check. ---- DONE



//Last I was working on & pending :
//- Implement Amazon keys from setup, to be used in Amz download API, access keys are hardcoded right now.
//- Invoice form design made, no logic implemented, Invoice model is empty, & Excel template needs to be made.