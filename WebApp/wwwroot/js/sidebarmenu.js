/*
Template Name: Admin Template
Author: Wrappixel

File: js
*/
// ==============================================================
// Auto select left navbar
// ==============================================================
$(function () {
    "use strict";

    let url = window.location + "";
    let path = url.replace(
        window.location.protocol + "//" + window.location.host + "/",
        ""
    );

    let element = $("ul#sidebarnav a").filter(function () {
        return this.href === url || this.href === path;
    });

    // Highlight the active link on page load
    element.addClass("active");

    $("#sidebarnav a").on("click", function (e) {
        //e.preventDefault();

        let clickedElement = $(this);

        if (!clickedElement.hasClass("active")) {
            // hide any open menus and remove all other classes
            $("ul", clickedElement.parents("ul:first")).removeClass("in");
            $("a", clickedElement.parents("ul:first")).removeClass("active");

            // open our new menu and add the open class
            clickedElement.next("ul").addClass("in");
            clickedElement.addClass("active");
        }
    });
});