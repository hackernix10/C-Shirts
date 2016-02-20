# C-Shirts

## Abstract

Customizable T-Shirts Dropshipping Platform

## Architecture

- all parts of the stack are described
- additionally, the current state of implementation is continually documented according to the *Legend* section

### Legend

- O => to be implemented
- X => dependencies implemented
- ✓ => functionality implemented

### Front-End

- O AngularJs
- O Angular UI Router

### Core

- X Mono
- O RestAngular
- X Nancy
- O Automapper

### Persistence

- X CouchDb
- X MyCouch .NET
- O JSON.NET

### Testing

- O xUnit.NET 1.9


## CouchDb

- Document based db, good for ddd, offline apps, provides well-performing scalability
- HTTP-based

### views

for custom views, JS map functions are used, e.g.:

	function(doc) {  
	  if(doc.$doctype !== 'artist')
	    return;

	  emit(doc.name, doc.albums);
	}

Link views editor:
[http://localhost:5984/_utils/database.html?cshirts/_temp_view](http://localhost:5984/_utils/database.html?cshirts/_temp_view)


## Security

**CouchDb**

User: `sa`

Password: `Pa$$w0rd`

### Class diagram

Conceptional class diagram

[class diagram]: http://s16.postimg.org/xs7z1xdmd/Screen_Shot_2016_02_10_at_15_53_01.png "Class Diagram"

## Literature

### Tutorials

#### CouchDb

[http://danielwertheim.se/get-up-and-running-with-couchdb-and-c-using-mycouch-on-windows/](http://danielwertheim.se/get-up-and-running-with-couchdb-and-c-using-mycouch-on-windows/)

#### Nancy

[http://www.jhovgaard.com/from-aspnet-mvc-to-nancy-part-3/](http://www.jhovgaard.com/from-aspnet-mvc-to-nancy-part-3/)

