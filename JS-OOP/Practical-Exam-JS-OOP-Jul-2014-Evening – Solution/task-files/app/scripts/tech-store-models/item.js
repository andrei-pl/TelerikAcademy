define(function () {
    'use strict';
    var Item;

    Item = (function() {
        var types = ['accessory', 'smart-phone', 'notebook', 'pc', 'tablet'],
            i, len;

        function Item(type, name, price) {
            if(checkForValidType(type)) {
                this._type = type;
            }
            if(checkForValidName(name)) {
                this._name = name;
            }
            if(isFinite(price)) {
                this._price = price;
            }
        }

        function checkForValidType(typeName){
            for(i = 0, len = types.length; i < len; i += 1){
                if(types[i] === typeName){
                    return true;
                }
            }

            return false;
        }

        function checkForValidName(name){
            if(name.length >= 6 && name.length <= 41){
                return true;
            } else {
                console.log("Invalid name");
            }

            return false;
        }

        return Item;
    }());
    return Item;
});