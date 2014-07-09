
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
			var out = '';
			if ( b10 >= this.base ) {
				out = this.encode( Math.floor( b10 / this.base ) );
				b10 = b10 % this.base;
			}
			out += this.glyphs[b10];
			return out;
		}
	}
	self.base = self.glyphs.length
	self.valid = new RegExp('^['+self.glyphs+']*$');

	return self;
}