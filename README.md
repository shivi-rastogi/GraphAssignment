# GraphAssignment
Graph Assignment is a simple client-server application. It includes a client in Angular to upload a file and save data in server using web Api. The processed data is displayed as Bar chart.

## Usage

* Upload file with sample data as below:

    #A:RED:5#B:BLUE:10#C:GREEN:20#D:YELLOW:20

* Uploaded file data is saved in server and data is sent back to client as JSON.
* Data displayed to the client is updated(randomized) every minute. Random data is retrived from server through web Api.

When the user uploads a new file, the previous results will be discarded, and the process starts over.
