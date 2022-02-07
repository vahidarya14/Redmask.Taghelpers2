const Helper2={

    refreshGrid(gridSelector) {
        var c = gridSelector[0];
        if (c != "#" && c != ".")
            gridSelector = '#' + gridSelector;
        $(gridSelector).data('kendoGrid').dataSource.read();
    }
    ,
    addAntiForgeryToken(data) {
        //if the object is undefined, create a new one.
        if (!data) data = {};

        //add token
        var tokenInput = $('input[name=__RequestVerificationToken]');
        if (tokenInput.length) {
            data.__RequestVerificationToken = tokenInput.val();
        }
        return data;
    }
    ,
    returnAntiForgeryToken() {
        const tokenInput = $('input[name=__RequestVerificationToken]');
        if (tokenInput.length) {
            return tokenInput.val();
        }
        return "";
    }

}