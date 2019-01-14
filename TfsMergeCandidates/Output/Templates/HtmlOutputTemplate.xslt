<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" indent="yes" version="4.0"/>
  <xsl:template match="/">


    <table align="center" cellpadding="8" cellspacing="0" width="100%">
      <tr>
        <th align="left" style="border-bottom: 2px solid Gray">
          <p style="font-size: 12px; font-weight:bold; font-family: Tahoma; color: #000;">
            Changeset
          </p>
        </th>
        <th align="left"  style="border-bottom: 2px solid Gray">
          <p style="font-size: 12px; font-weight:bold; font-family: Tahoma; color: #000;">
            Developer
          </p>
        </th>
        <th align="left"  style="border-bottom: 2px solid Gray">
          <p style="font-size: 12px; font-weight:bold; font-family: Tahoma; color: #000;">
            Date
          </p>
        </th>
        <th align="left"  style="border-bottom: 2px solid Gray">
          <p style="font-size: 12px; font-weight:bold; font-family: Tahoma; color: #000;">
            Comment
          </p>
        </th>
      </tr>

      <xsl:for-each select="MergeCandidateContainer/Candidates/MergeItem">
        <tr>
          <td style="vertical-align: top; border-bottom: 1px solid Gray">
            <p style="font-size: 12px; font-family: Tahoma; color: #404040;">
             #<xsl:value-of select="ChangesetId"/>
            </p>
          </td>
          <td style="vertical-align: top; border-bottom: 1px solid Gray">
            <p style="font-size: 12px; font-weight: bold; font-family: Tahoma; color: #404040;">
              <xsl:value-of select="Committer"/>
            </p>
          </td>
          <td style="vertical-align: top; border-bottom: 1px solid Gray">
            <p style="font-size: 12px; font-family: Tahoma; color: #404040;">
              <xsl:value-of select="CheckinDate"/>
            </p>
          </td>
          <td style="vertical-align: top; border-bottom: 1px solid Gray">
            <p style="font-size: 12px; font-family: Tahoma; color: #404040; text-decoration: italic;">
              <xsl:value-of select="Comment"/>
            </p>
          </td>
        </tr>
      </xsl:for-each>
      
    </table>

  </xsl:template>
</xsl:stylesheet>