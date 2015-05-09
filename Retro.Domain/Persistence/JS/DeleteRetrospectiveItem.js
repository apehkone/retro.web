﻿/// <reference group="Generic" />
/// <reference path="C:\Program Files (x86)\Microsoft Visual Studio 12.0\JavaScript\References\DocDbWrapperScript.js" />
function(retroId, categoryId, itemId) {
    var context = getContext();
    var collection = context.getCollection();
    var response = context.getResponse();

    collection.queryDocuments(collection.getSelfLink(), 'SELECT * FROM retro r where r.id = "' + retroId + '"', {},
        function(err, doc) {
            if (err) throw err;
            if (!doc || !doc.length) {
                response.setBody("Document with id: " + retroId + " not found.");
                return;
            }

            var retro = doc[0];

            if (!retro.categories) {
                response.setBody("Categories with id: " + retroId + " not found.");
                return;
            }

            for (var i = 0, len = retro.categories.length; i < len; i++) {
                if (categoryId === retro.categories[i].id) {
                    if (retro.categories[i].items) {
                        retro.categories[i].items.forEach(function(it) {
                            if (it.id === itemId) {
                                Array.splice(Array.indexOf(it), 1);
                                retro.updatedOn = new Date().toJSON().toString();
                                collection.replaceDocument(retro._self, retro, {});
                                response.setBody(true);
                                return;
                            }
                        });
                    }
                }
            }
            response.setBody(false);
        });
}