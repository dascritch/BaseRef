function BaseRef() {
    var self = {
        base : 0,
        valid : /^$/,
        // glyphs : '0123456789ACDEFHJKMNPQRTUVWX',
        glyphs : '',
        isValid : function(validate) {
            return self.valid.test(validate);
        },
        exception : function(message) {
            console.error(message);
        },
        encode : function(b10) {
            if (Number.isNaN(b10)) {
                self.exception('not a number');
                return false;
            }
            b10 = Number(b10);
            if ( (b10<0) || ( Math.floor(b10) != b10) ) {
                self.exception('not a positive integer');
                return false;
            }
            var out = '';
            if ( b10 >= self.base ) {
                out = self.encode( Math.floor( b10 / self.base ) );
                b10 = b10 % self.base;
            }
            out += self.glyphs[b10];
            return out;
        },
        decode : function(based , multiplicande) {
            based = based.toUpperCase();
            if (!self.isValid(based)) {
                self.exception('not a valid coded-number');
                return false;
            }
            var numeric = 0;
            multiplicande = multiplicande===undefined ? 0 : multiplicande;
            if (based.length > 1) {
                numeric += self.decode( based.substr(0,based.length-1) , multiplicande++ ) * Math.pow( self.base, multiplicande );
                based = based.substr(-1);
            }
            numeric += self.glyphs.indexOf( based );
            return numeric;
        },
        redefine_glyphs : function(glyphs) {
            self.glyphs = glyphs;
            self.base = self.glyphs.length;
            self.valid = new RegExp('^['+self.glyphs+']*$');            
        }
    }
    self.redefine_glyphs('0123456789ACDEFHJKMNPQRTUVWX');

    return self;
}
