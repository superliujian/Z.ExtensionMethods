
' Copyright (c) 2015 ZZZ Projects. All rights reserved
' Licensed under MIT License (MIT) (https://github.com/zzzprojects/Z.ExtensionMethods)
' Website: http://www.zzzprojects.com/
' Feedback / Feature Requests / Issues : http://zzzprojects.uservoice.com/forums/283927
' All ZZZ Projects products: Entity Framework Extensions / Bulk Operations / Extension Methods /Icon Library


Public Module Extensions_92

	''' <summary>
	'''     Indicates whether the specified Unicode character is categorized as a lowercase letter.
	''' </summary>
	''' <param name="c">The Unicode character to evaluate.</param>
	''' <returns>true if  is a lowercase letter; otherwise, false.</returns>
	<System.Runtime.CompilerServices.Extension> _
	Public Function IsLower(c As [Char]) As [Boolean]
		Return [Char].IsLower(c)
	End Function
End Module


