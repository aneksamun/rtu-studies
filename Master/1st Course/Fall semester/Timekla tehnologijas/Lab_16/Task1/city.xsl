<?xml version="1.0"?>
<xsl:stylesheet xmlns:xsl=
    "http://www.w3.org/TR/WD-xsl">
    <xsl:template match="/">
      <table id="TableInfo" border="2" cellpadding="4" width="100%">
        <caption align="Center">
            <h2>Inhabitants</h2>
         </caption>
         <xsl:for-each select="RIGA/STREET">
            <tr style="background-color:yellow">
                <td>
                    <strong>Street: </strong>
                    <xsl:value-of select="@Name" />
                </td>
            </tr>
            <tr>
                <td>
                    <table border="1" cellpadding="4" width="100%">
                        <xsl:for-each select="HOUSE">
                            <tr style="background-color:green">
                                <td>
                                    <strong>House: </strong>
                                    <xsl:value-of select="@No" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table datafld="FLAT" cellpadding="4" width="100%">
                                        <xsl:for-each select="FLAT">
                                            <tr>
                                                <td>
                                                    <strong>Flat: </strong> 
                                                    <xsl:value-of select="@No" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table border="1" cellpadding="4" width="100%">
                                                         <thead>
                                                            <tr>
                                                                <th>Surname, name</th>
                                                                <th>Gender</th>
                                                                <th>Year of birth</th>
                                                            </tr>
                                                        </thead>
                                                            <xsl:for-each select="INHABITANT">
                                                                <tr>
                                                                    <td width="70%"><xsl:value-of select="."/></td>
                                                                    <td width="10%" style="text-align:center"><xsl:value-of select="@Gender"/></td>
                                                                    <td width="20%" style="text-align:center"><xsl:value-of select="@Year"/></td>
                                                                </tr>
                                                            </xsl:for-each>
                                                    </table> 
                                                </td>
                                            </tr>
                                        </xsl:for-each>
                                    </table>
                                </td>
                            </tr>
                        </xsl:for-each>
                    </table>
                </td>
            </tr>
         </xsl:for-each>
      </table>
    </xsl:template>
</xsl:stylesheet>

