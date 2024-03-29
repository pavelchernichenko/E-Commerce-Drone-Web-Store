﻿$(".alert").hide();

function validateForm() {
    let flag = true;
    $(".form-control").each(function (index, value) {
        if (index === 6) {
            let result = $(value).val().search("@");
            if (result === -1) {
                $(value).css("background-color", "#ffe8e8");
                flag = false;
            }
        }
        else if ($(value).attr("required") == "required" && $(value).val() == '') {
            flag = false;
            $(value).css("background-color", "#ffe8e8");
        }
        if (!flag) {
            $(".alert").html(
                `<strong>Error:</strong> fields that are red are invalid.
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close" >
                        <span aria-hidden="true">&times;</span>
                    </button>`);
            $(".alert").show();
        }
    });
    return flag;
}