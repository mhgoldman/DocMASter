# DocMASter
#### Poor man's scan attachment manager for [Sage 100](http://www.sage.com/us/erp/sage-100), formally MAS 200. Built for [Total Machine Solutions](http://totalmachinesolutions.com).
This application enables users to scan documents and associate them to Sage 100 records (sales orders, POs, etc.) The intended workflow is as follows:

* User scans document from a shared network scanner to a predefined file share ("scanner dropbox")
* User accesses the desired record in Sage 100 and clicks a custom "Docs" button
* A DocMASter window appears, where the user can "claim" the doc from the dropbox to associate it with the selected record
* The doc is moved from the dropbox to its own repository, a separate file share, where it is associated with the record and now appears in the DocMASter window for that record going forward.

Please note that this application was intended to solve a specific problem at a specific business. It may be a bit rough around the edges.

#### Building
This is a .NET project and required Visual Studio 2012 and InstallShield 2012 LE. (Newer versions may work but have not been tested.)

To build, simply open the solution in Visual Studio. Navigate to DocMASterSetup project > Specify Application Data > Redistributables, then right-click "Microsoft .NET Framework 4.5 Web" and select download. Once completed, you should be able to build the setup project and take the resulting installer to your client PC(s) for installation.

#### Backend Preparation
You should have two file shares configured, a Scanner Dropbox and a Doc Repository. All users who will be "claiming" docs need to have full access rights to both shares. Of course, whatever user account is being used by your scanner to copy files there will need access to the Scanner Dropbox as well. It is *highly* recommended that you regularly back up the Doc Repository share.

#### Sage 100 Preparation
The Custom Office module enables MAS administrators to customize forms within the application. You will need to use this functionality to add a "Docs" button to the form for each record type (e.g. sales orders) that you want to associate docs to. Configure the button to execute a custom command as follows:

"C:\Program Files(x86)\Total Machine Solutions\DocMASter\DocMASter.exe" [RecordType] [RecordID]

Replace [RecordType] with the type of Sage 100 record (e.g. SalesOrder). Custom Office must be configured to replace the [RecordID] placeholder with the ID of the record being accessed.

#### Client Preparation
The DocMASter package built previously must be installed on every client and the install path must be the same on all clients.

Please note that the install path must be the same on all clients and must match the path specified in the Sage 100 Preparation section listed above. A network install of the DocMASter binary may be possible but I haven't tried it.

In addition, you must configure DocMASter on each client with a registry key, HKEY_LOCAL_MACHINE\Software\Wow6432Node\Total Machine Solutions\DocMASter. Add the following values:
* docDropBoxPath - the UNC path to the Scanner Dropbox share
* docLibraryPath - the UNC path to the Doc Repository share
