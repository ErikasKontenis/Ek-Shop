declare global {
    interface String {
        format(...replacements: string[]): string;
        firstLetterToLowerCase(): string;
        firstLetterToUpperCase(): string;
    }
}

if (!String.prototype.format) {
  String.prototype.format = function() {
    var args = arguments;
    return this.replace(/{(\d+)}/g, function(match, number) { 
      return typeof args[number] != 'undefined'
        ? args[number]
        : match
      ;
    });
  };
}

if (!String.prototype.firstLetterToLowerCase) {
    String.prototype.firstLetterToLowerCase = function () {
        if (!this) {
            return this;
        }

        return this.charAt(0).toLowerCase() + this.slice(1);
    };
}

if (!String.prototype.firstLetterToUpperCase) {
    String.prototype.firstLetterToUpperCase = function () {
        if (!this) {
            return this;
        }

        return this.charAt(0).toUpperCase() + this.slice(1);
    };
}

export class StringPrototype {

}
