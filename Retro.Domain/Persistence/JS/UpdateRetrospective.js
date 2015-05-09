/// <reference group="Generic" />
/// <reference path="C:\Program Files (x86)\Microsoft Visual Studio 12.0\JavaScript\References\DocDbWrapperScript.js" />

function(item) {
    var context = getContext();
    var collection = context.getCollection();
    var response = context.getResponse();

    collection.queryDocuments(collection.getSelfLink(), 'SELECT * FROM retro r where r.id = "' + item.id + '"', {},
        function(err, doc) {
            if (err) throw err;
            if (!doc || !doc.length) {
                response.setBody("Document with id: " + item.id + " not found.");
                return;
            }

            var retro = doc[0];
            retro.description = item.description;
            retro.updatedOn = new Date().toJSON().toString();

            collection.replaceDocument(retro._self, retro, {});
            response.setBody(true);
        });
}
