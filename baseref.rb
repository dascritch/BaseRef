class BaseRef

	def initialize()
		@glyphs = '0123456789ACDEHFJKMNPQRTUVWX'
		@rule = Regexp.new('^['+ @glyphs +']*$')
	end

	def isValid(validate)
		return ( @rule =~ validate ) == 0
	end

	def encode(b10)
		if ( (b10.is_a? String) )
			b10 = b10.to_i(10)
		end
		out = ""
		if (b10 >= @glyphs.length)
			out +=  self.encode( (b10/@glyphs.length).floor )
			b10 = b10 % @glyphs.length
		end
		out += @glyphs[b10]
	end
end
