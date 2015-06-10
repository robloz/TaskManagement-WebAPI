

function LoadPriorities(){

    $.getJSON("/api/Priorities", null, 
        
            function Display(data) {

                var subItems = "<h3>Priorities</h3>" + "<ul>";

                $.each(data, function (index, item) {
                    subItems += "<li>" + item.NamePriority + " - " + item.Ordinal +"</li>"
                });

                subItems += "</ul>",
                $("#showItemMenu").html(subItems);
                CleanDetails();
            }
        
        );
}

function LoadCategories() {

    $.getJSON("/api/Categories", null,

            function Display(data) {

                var subItems = "<h3>Categories</h3>" + "<ul>";

                $.each(data, function (index, item) {
                    subItems += "<li>" + item.NameCategory + ": " + item.DescriptionCategory + "</li>"
                });

                subItems += "</ul>",
                $("#showItemMenu").html(subItems);
                CleanDetails();
            }

        );
}

function LoadTasks() {

    $.getJSON("/api/Task", null,

            function Display(data) {

                var subItems = "<h3>Tasks</h3>" + "<ul>";

                $.each(data, function (index, item) {
                    subItems += "<li>" + item.SubjectTask
                               + "<a href='javascript:void(0);' onclick='GetTask(" + item.Id + ")'>Details</a>"
                               + "</li>"
                });

                subItems += "</ul>";
                $("#showItemMenu").html(subItems);
                CleanDetails();
            }

        );
}

function GetTask(idTask) {

    $.getJSON("/api/Task/"+idTask, null,

            function Display(data) {
                var city = data.Place;
                var subItems = "<h3>"+data.SubjectTask+"</h3>";

                subItems += "<p>Start Date: " + data.StartDate + "</p>";
                subItems += "<p>Due Date: " + data.DueDate + "</p>";
                subItems += "<p>Date Completed: " + data.DateCompleted + "</p>";
                subItems += "<p>Creation Date: " + data.CreateDate + "</p>";

                subItems += "<p>Categories: " + data.Categories.Length + "</p>";
                subItems += "<p>Place: " + data.Place + "</p>";

                $("#showDetailsItem").html(subItems);

                $.getJSON("https://maps.googleapis.com/maps/api/geocode/json?address="+data.Place, null,

                        function Display(data) {

                            displayMapAt(city, data.results[0].geometry.location.lat, data.results[0].geometry.location.lng, 10);
                        }

                    );

            }

        );
}

function CleanDetails() {
    $("#showDetailsItem").html("");
    $("#map").html("");
}


function displayMapAt(city, lat, lon, zoom) {
        $("#map")
                .html("<h3>" + city + "</h3>" +
                        "<iframe id=\"map_frame\" "
                                + "width=\"400px\" height=\"400px\" frameborder=\"0\" scrolling=\"no\" marginheight=\"0\" marginwidth=\"0\" "
                                + "src=\"https://www.google.sk/maps?f=q&amp;output=embed&amp;source=s_q&amp;hl=sk&amp;geocode=&amp;q=https:%2F%2Fwww.google.sk%2Fmaps%2Fms%3Fauthuser%3D0%26vps%3D5%26hl%3Dsk%26ie%3DUTF8%26oe%3DUTF8%26msa%3D0%26output%3Dkml%26msid%3D205427380680792264646.0004fe643d107ef29299a&amp;aq=&amp;sll=48.669026,19.699024&amp;sspn=4.418559,10.821533&amp;ie=UTF8&amp;ll="
                                + lat + "," + lon
                                + "&amp;spn=0.199154,0.399727&amp;t=m&amp;z="
                                + zoom + "\"" + "></iframe>");

    }
