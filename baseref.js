/**
 * encode sould respond false on untranslatable
 * decode sould respond false on untranslatable
 * decode should be case insensitive
 */


function BaseRef() {
	var self = {
		base : 0,
		valid : /^$/,

		glyphs : '0123456789ACDEFGHJKMNPQRTUVWX',
		isValid : function(validate) {
			return this.valid.test(validate);
		},
		exception : function(message) {
			console.error(message);
		},
		encode : function(b10) {
			if (Number.isNaN(b10)) {
				return false;
			}
			b10 = Number(b10);
			if ( (b10<0) || ( Math.floor(b10) != b10) ) {
				return false;
			}
			var out = '';
			if ( b10 >= this.base ) {
				out = this.encode( Math.floor( b10 / this.base ) );
				b10 = b10 % this.base;
			}
			out += this.glyphs[b10];
			return out;
		},
		decode : function(based , multiplicande) {
			based = based.toUpperCase();
			if (!this.isValid(based)) {
				return false;
			}
			var numeric = 0;
			multiplicande = multiplicande===undefined ? 0 : multiplicande;
			if (based.length > 1) {
				numeric += this.decode( based.substr(0,based.length-1) , multiplicande++ ) * Math.pow( this.base, multiplicande );
				based = based.substr(-1);
			}
			numeric += this.glyphs.indexOf( based );
			return numeric;
		}
	}
	self.base = self.glyphs.length
	self.valid = new RegExp('^['+self.glyphs+']*$');

	return self;
}