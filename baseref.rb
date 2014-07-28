class BaseRef

	def initialize()
		@glyphs = '0123456789ACDEHFJKMNPQRTUVWX'
		@rule = Regexp.new('^['+ @glyphs +']*$')
	end

	def isValid(validate)
		return ( @rule =~ validate ) == 0
	end

	def encode(b10)
		b10 = b10.to_i(10)
		if (b10 >= @glyphs.length)
			return "10"
		end
		return @glyphs[b10]
	end
end
