
function BaseRef() {
	var self = {
		glyphs : '0123456789ACDEFGHJKMNPQRTUVWX',
		isValid : function(validate) {
			return this.valid.test(validate);
		},
		encode : function(b10) {
			var out = '';
			return b10;
		}
	}
	self.valid = new RegExp('^['+self.glyphs+']*$');

	return self;
}