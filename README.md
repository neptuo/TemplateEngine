# TemplateEngine
Proof of concept of dynamic CMS with server and client (javascript) complete rendering (and shared) pipeline. Application is based on [Neptuo.Templates](https://github.com/neptuo/Templates) and provides server and javascript rendering pipelines.

Views are defines only and can be transparently run by standart HTTP requests, that renders content (HTML) on server and transfers it to the client, and both javascript-only rendering. The later case compiled views into javascript are donwload in the initial request and than navigation is done only by downloading JSON data using AJAX and rendering those data by compiled views.
Also, the initial request (or when F5 is hit in the browse) downloads server rendered page (you requested by URL) and bunch of compiled views. Then, click to any link only triggers javascript rendering and downloading (if required by the view) JSON data. Compiled views are cached in the browse cache, so only changing JSON data are transfered.

This repository is also the source code of Master thesis by [Marek Fišera](https://github.com/maraf).
