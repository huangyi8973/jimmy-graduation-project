function page(pagenow, pagecount, n, uri, context) {
    var nextpage;
    var prepage;
    var pagenav = new Array();
    if (pagenow <= pagecount && pagenow > 0) {
        if (pagenow <= n) {
            if (pagecount <= (2 * n + 1)) {
                for (var i = 1; i <= pagecount; i++) {
                    pagenav[i] = i;
                }
            }
            else {
                for (var i = 1; i <= (2 * n + 1); i++) {
                    pagenav[i] = i;
                }
            }
        }
        else if (pagenow >= pagecount - n) {
            for (var i = 1, p = pagecount - (2 * n); i <= (2 * n + 1); i++, p++) {
                pagenav[i] = p;
            }
        }
        else {
            for (var i = 1, p = pagenow - n; i <= (2 * n + 1); i++, p++) {
                pagenav[i] = p;
            }
        }
        //--out
        result_str = "";
        if (pagenow > 1 && pagenow <= pagecount) {
            prepage = pagenow - 1;
            result_str += ("<a href='" + uri + prepage + "'>上一页</a> ");
        }

        for (var i in pagenav) {
            if (pagenav[i] == pagenow) {
                result_str += ("<a href='" + uri + pagenav[i] + "' class='number current'>" + pagenav[i] + "</a> ");
            }
            else {
                result_str += ("<a href='" + uri + pagenav[i] + "' class='number'>" + pagenav[i] + "</a> ");
            }
        }
        if (pagenow < pagecount && pagenow > 0) {
            nextpage = pagenow + 1;
            result_str += ("<a href='" + uri + nextpage + "'>下一页</a> ");
        }
    }
    $(context).html(result_str);
}

function PremissionOperate () {
    var canView = $("#CanView");
    var canDetail = $("#CanDetail");
    var canAdd = $("#CanAdd");
    var canEdit = $("#CanEdit");
    var canDel = $("#CanDel");

    canView.click(function () {
        if ($(this).attr("checked") == false) {
            canDetail.attr("checked", false);
            canAdd.attr("checked", false);
            canEdit.attr("checked", false);
            canDel.attr("checked", false);
        }
    });

    canDetail.click(function () {
        if ($(this).attr("checked") == true) {
            canView.attr("checked", true);
        }
    });
    canAdd.click(function () {
        if ($(this).attr("checked") == true) {
            canView.attr("checked", true);
        }
    });
    canEdit.click(function () {
        if ($(this).attr("checked") == true) {
            canView.attr("checked", true);
        }
    });
    canDel.click(function () {
        if ($(this).attr("checked") == true) {
            canView.attr("checked", true);
        }
    });
}