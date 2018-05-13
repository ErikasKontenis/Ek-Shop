//declare global {
//    interface Object {
//        deepClone(): string;
//    }
//}


//if (!Object.prototype.deepClone) {
//    Object.prototype.deepClone = function () {
//        // Lodash library deepClone method
//        function deepClone(obj) {
//            // return value is input is not an Object or Array.
//            if (typeof (obj) !== 'object' || obj === null) {
//                return obj;
//            }

//            let clone;

//            if (Array.isArray(obj)) {
//                clone = obj.slice();  // unlink Array reference.
//            } else {
//                clone = Object.assign({}, obj); // Unlink Object reference.
//            }

//            let keys = Object.keys(clone);

//            for (let i = 0; i < keys.length; i++) {
//                clone[keys[i]] = deepClone(clone[keys[i]]); // recursively unlink reference to nested objects.
//            }

//            return clone; // return unlinked clone.

//        }

//        return deepClone(this);
//    }
//}

export class ObjectPrototype {

}
