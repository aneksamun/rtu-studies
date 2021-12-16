<?xml version="1.0"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="/">
		<MALES>
		<xsl:text>&#10;</xsl:text>
		<xsl:for-each 
			select="/RIGA/STREET/HOUSE/FLAT/INHABITANT">
			<xsl:if test = "@Sex = 'M'">
				<MALE>
				<xsl:value-of select="." />
				</MALE>
				<xsl:text>&#10;</xsl:text>
			</xsl:if>
		</xsl:for-each>
		</MALES>
	</xsl:template>
</xsl:stylesheet>