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
			if ( ( b10 =~ /^\d+$/ ) != 0 )
				return false
			end
			b10 = b10.to_f
		end
		if ( (b10 < 0) || (b10 != b10.floor) )
			return false
		end
		b10 = b10.to_i
		out = ''
		if (b10 >= @glyphs.length)
			out +=  self.encode( (b10/@glyphs.length).floor )
			b10 = b10 % @glyphs.length
		end
		out += @glyphs[b10]
	end

	def decode(based)
		based = based.upcase
		if ( self.isValid(based) == false)
			return false
		end
		numeric = 0
		if (based.length > 1)
			numeric += self.decode(based[0,based.length-1]) * @glyphs.length
			based = based[-1]
		end
		numeric += @glyphs.index(based)
		return numeric
	end
end
