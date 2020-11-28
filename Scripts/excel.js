function excelExport() {
    var tab_excel = "<table border='2px'><tr bgcolor='#87AFC6'>";
    var j = 0;

    tab = document.getElementById('contacts');

    for (j = 0; j < tab.rows.length; j++) {
        tab_excel = tab_excel + tab.rows[j].innerHTML + "</tr>";
    }

    tab_excel = tab_excel + "</table>";
    tab_excel = tab_excel.replace(/<A[^>]*>|<\/A>/g, "");
    tab_excel = tab_excel.replace(/<img[^>]*>/gi, "");
    tab_excel = tab_excel.replace(/<input[^>]*>|<\/input>/gi, "");

    var ua = window.navigator.userAgent;
    var msie = ua.indexOf("MSIE ");

    while (tab_excel.indexOf('ą') != -1) tab_excel = tab_excel.replace('ą', '&#261;');
    while (tab_excel.indexOf('ć') != -1) tab_excel = tab_excel.replace('ć', '&#263;');
    while (tab_excel.indexOf('ę') != -1) tab_excel = tab_excel.replace('ę', '&#281;');
    while (tab_excel.indexOf('ł') != -1) tab_excel = tab_excel.replace('ł', '&#322;');
    while (tab_excel.indexOf('ń') != -1) tab_excel = tab_excel.replace('ń', '&#324;');
    while (tab_excel.indexOf('ó') != -1) tab_excel = tab_excel.replace('ó', '&#243;');
    while (tab_excel.indexOf('ś') != -1) tab_excel = tab_excel.replace('ś', '&#347;');
    while (tab_excel.indexOf('ź') != -1) tab_excel = tab_excel.replace('ź', '&#378;');
    while (tab_excel.indexOf('ż') != -1) tab_excel = tab_excel.replace('ż', '&#380;');

    while (tab_excel.indexOf('Ą') != -1) tab_excel = tab_excel.replace('Ą', '&#260;');
    while (tab_excel.indexOf('Ć') != -1) tab_excel = tab_excel.replace('Ć', '&#262;');
    while (tab_excel.indexOf('Ę') != -1) tab_excel = tab_excel.replace('Ę', '&#280;');
    while (tab_excel.indexOf('Ł') != -1) tab_excel = tab_excel.replace('Ł', '&#321;');
    while (tab_excel.indexOf('Ń') != -1) tab_excel = tab_excel.replace('Ń', '&#323;');
    while (tab_excel.indexOf('Ó') != -1) tab_excel = tab_excel.replace('Ó', '&#211;');
    while (tab_excel.indexOf('Ś') != -1) tab_excel = tab_excel.replace('Ś', '&#346;');
    while (tab_excel.indexOf('Ź') != -1) tab_excel = tab_excel.replace('Ź', '&#377;');
    while (tab_excel.indexOf('Ż') != -1) tab_excel = tab_excel.replace('Ż', '&#379;');

    if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./)) {
        txtArea1.document.open("txt/html;", "replace");
        txtArea1.document.write(tab_excel);
        txtArea1.document.close();
        txtArea1.focus();
        result = frame.document.execCommand("SaveAs", true);
    }
    else {
        result = window.open('data:application/vnd.ms-excel,' + encodeURIComponent(tab_excel));
    }

    return (result);
}