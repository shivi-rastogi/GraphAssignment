# GraphAssignment
Graph Assignment is a simple client-server application. It includes a client in Angular to upload a file and save data in server using ASP.Net web Api. The processed data is displayed as Bar chart. Unit tests are included in the solution.

## Usage

* Upload file with sample data as below:

    #A:RED:5#B:BLUE:10#C:GREEN:20#D:YELLOW:20

* Uploaded file data is saved in server and data is sent back to client as JSON.
* Data displayed to the client is updated(randomized) every minute. Random data is retrived from server through ASP.Net web Api.

When the user uploads a new file, the previous results will be discarded, and the process starts over.

## Steps to setup application

* Angular - Execute npm install to add node modules.
* ASP.Net Web API - Data is stored in local sql server db. To setup db, execute update database command in package manager console.
