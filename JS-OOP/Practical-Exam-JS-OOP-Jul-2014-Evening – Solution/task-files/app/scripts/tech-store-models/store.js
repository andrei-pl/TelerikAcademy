define(['tech-store-models/item'], function (Item) {
    'use strict';
    var Store;
    Store = (function() {
        function Store(name) {
            if(checkForValidStoreName(name)) {
                this._name = name;
            }

            this._items = [];
        }

        function checkForValidStoreName(name){
            if(name.length >= 6 && name.length <= 30){
                return true;
            } else {
                console.log('Invalid Store name');
            }

            return false;
        }

        function sortByProp(array, name){
            return array.sort(function(first, second){
                return first[name].localeCompare(second[name]);
            })
        };

        function pushByProp(array, type){
            var self = this;
            var newArray = array.slice(0);

            this._items.forEach(function(item){

                if(item._type == type){
                    newArray.push(item);
                }
            });

            return newArray;
        };

        Store.prototype = {
            addItem: function(item){
                if(!(item instanceof Item)){
                    return console.log('This is not instance of Item');
                }

                this._items.push(item);
                return this;
            },

            getAll: function(){
                var sortedItems;
                sortedItems = this._items.slice(0);

                sortedItems = sortByProp(sortedItems, '_name');

                return sortedItems;
            },

            getSmartPhones: function(){
                var sortedSmartPhones, i, len, self;

                sortedSmartPhones = [];

                sortedSmartPhones = pushByProp.call(this, sortedSmartPhones, 'smart-phone');
                sortedSmartPhones = sortByProp(sortedSmartPhones, '_name');

                return sortedSmartPhones;
            },

            getMobiles: function(){
                var sortedMobiles;

                sortedMobiles = [];

                sortedMobiles = pushByProp.call(this, sortedMobiles, 'smart-phone');
                sortedMobiles = pushByProp.call(this, sortedMobiles, 'tablet');

                sortedMobiles  = sortByProp(sortedMobiles, '_name');

                return sortedMobiles;
            },

            getComputers: function(){
                var sortedComputers;

                sortedComputers = [];

                sortedComputers = pushByProp.call(this, sortedComputers, 'pc');
                sortedComputers = pushByProp.call(this, sortedComputers, 'notebook');

                sortedComputers = sortByProp(sortedComputers, '_name');

                return sortedComputers;
            },

            filterItemsByType: function(filterType){
                var filterByType;

                filterByType = [];
                filterByType = pushByProp.call(this, filterByType, filterType);

                filterByType = sortByProp(filterByType, '_name');

                return filterByType;
            },

            filterItemsByPrice: function(prices){
                var filterByPrice, min, max, price;

                //min = prices.min || 0;  //ne znam zashto, no ne raboti taka
                //max = prices.max || 2000000000;

                if(prices){
                    if(prices.min){
                        min = prices.min;
                    }else{
                      min = 0;
                    }
                    if(prices.max){
                        max = prices.max;
                    }else{
                        max = 2000000000;
                    }
                } else {
                    min = 0;
                        max = 2000000000;
                }

                filterByPrice = [];
                this._items.forEach(function(item){

                    if(item._price > min && item._price < max){
                        filterByPrice.push(item);
                    }
                });

                filterByPrice.sort(function(first, second) {
                    return first._price - second._price;
                });

                return filterByPrice;
            },

            countItemsByType: function(){
                var sortedByType, items, type, i, len, self;
                sortedByType = [];
                items = this._items.slice(0);

                items = sortByProp(items, '_type');

                for(i = 0, len = items.length; i < len; i += 1){
                    type = items[i]._type;
                    if(!sortedByType[type]){
                        sortedByType[type]= {};
                        sortedByType[type].key = type;
                        sortedByType[type].value = 1;
                    }else{
                        sortedByType[type].value += 1;
                    }
                }

                return sortedByType;
            },

            filterItemsByName: function(partOfName){
                var sortedByPartOfName, i, len, self;

                self = this;
                sortedByPartOfName = [];
                this._items.forEach(function(item){

                    if(item._name.toLowerCase().indexOf(partOfName.toLowerCase()) > -1){
                        sortedByPartOfName.push(item);
                    }
                });

                sortedByPartOfName = sortByProp(sortedByPartOfName, '_name');

                return sortedByPartOfName;
            }

        }
        return Store;
    }());
    return Store;
});