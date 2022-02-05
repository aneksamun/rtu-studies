import oracle.xml.parser.v2.XMLDocument;
import oracle.xml.parser.v2.DOMParser;
import org.w3c.dom.Node;
import oracle.spatial.util.*;
import oracle.spatial.geometry.JGeometry;

public class TestManyGeoms
{
  public static void main(String args[])
      throws Exception
  {    
    String multiGeomsGml[] =
      new String[] {
        "<gml:MultiPolygon srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:polygonMember>\n" +
        "    <gml:Polygon>\n" +
        "      <gml:outerBoundaryIs>\n" +
        "        <gml:LinearRing>\n" +
        "          <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">\n" +
        "            28,26 28,0 84,0 84,42 28,26\n" +
        "          </gml:coordinates>\n" +
        "        </gml:LinearRing>\n" +
        "      </gml:outerBoundaryIs>\n" +
        "      <gml:innerBoundaryIs>\n" +
        "        <gml:LinearRing>\n" +
        "          <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">\n" +
        "            52,18 66,23 73,9 48,6 52,18\n" +
        "          </gml:coordinates>\n" +
        "        </gml:LinearRing>\n" +
        "      </gml:innerBoundaryIs>\n" +
        "    </gml:Polygon>\n" +
        "  </gml:polygonMember>\n" +
        "  <gml:polygonMember>\n" +
        "    <gml:Polygon>\n" +
        "      <gml:outerBoundaryIs>\n" +
        "        <gml:LinearRing>\n" +
        "          <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">\n" +
        "            59,18 59,13 67,13 67,18 59,18\n" +
        "          </gml:coordinates>\n" +
        "        </gml:LinearRing>\n" +
        "      </gml:outerBoundaryIs>\n" +
        "    </gml:Polygon>\n" +
        "  </gml:polygonMember>\n" +
        "</gml:MultiPolygon>\n",

        "<gml:MultiPolygon srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:polygonMember>\n" +
        "    <gml:Polygon>\n" +
        "      <gml:outerBoundaryIs>\n" +
        "        <gml:LinearRing>\n" +
        "          <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">\n" +
        "            24,44 22,42 24,40 24,44\n" +
        "          </gml:coordinates>\n" +
        "        </gml:LinearRing>\n" +
        "      </gml:outerBoundaryIs>\n" +
        "    </gml:Polygon>\n" +
        "  </gml:polygonMember>\n" +
        "  <gml:polygonMember>\n" +
        "    <gml:Polygon>\n" +
        "      <gml:outerBoundaryIs>\n" +
        "        <gml:LinearRing>\n" +
        "          <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">\n" +
        "            26,44 26,40 28,42 26,44\n" +
        "          </gml:coordinates>\n" +
        "        </gml:LinearRing>\n" +
        "      </gml:outerBoundaryIs>\n" +
        "    </gml:Polygon>\n" +
        "  </gml:polygonMember>\n" +
        "</gml:MultiPolygon>\n",

        "<gml:MultiPolygon srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:polygonMember>\n" +
        "    <gml:Polygon>\n" +
        "      <gml:outerBoundaryIs>\n" +
        "        <gml:LinearRing>\n" +
        "          <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">\n" +
        "            0,0 4,0 4,4 0,4 0,0\n" +
        "          </gml:coordinates>\n" +
        "        </gml:LinearRing>\n" +
        "      </gml:outerBoundaryIs>\n" +
        "      <gml:innerBoundaryIs>\n" +
        "        <gml:LinearRing>\n" +
        "          <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">\n" +
        "            1,1 1,2 2,2 2,1 1,1\n" +
        "          </gml:coordinates>\n" +
        "        </gml:LinearRing>\n" +
        "      </gml:innerBoundaryIs>\n" +
        "    </gml:Polygon>\n" +
        "  </gml:polygonMember>\n" +
        "  <gml:polygonMember>\n" +
        "    <gml:Polygon>\n" +
        "      <gml:outerBoundaryIs>\n" +
        "        <gml:LinearRing>\n" +
        "          <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">\n" +
        "            -1,-1 -2,-1 -2,-2 -1,-2 -1,-1\n" +
        "          </gml:coordinates>\n" +
        "        </gml:LinearRing>\n" +
        "      </gml:outerBoundaryIs>\n" +
        "    </gml:Polygon>\n" +
        "  </gml:polygonMember>\n" +
        "</gml:MultiPolygon>\n",

        "<gml:LinearRing srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">\n" +
        "    28,26 28,0 84,0 84,42 28,26\n" +
        "  </gml:coordinates>\n" +
        "</gml:LinearRing>\n",

        "<gml:MultiGeometry srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:geometryMember>\n" +
        "    <gml:Point srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">64,33 </gml:coordinates>\n" +
        "    </gml:Point>\n" +
        "  </gml:geometryMember>\n" +
        "  <gml:geometryMember>\n" +
        "    <gml:Polygon srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "      <gml:outerBoundaryIs>\n" +
        "        <gml:LinearRing>\n" +
        "          <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">66,34 62,34 62,32 66,32 66,34 </gml:coordinates>\n" +
        "        </gml:LinearRing>\n" +
        "      </gml:outerBoundaryIs>\n" +
        "    </gml:Polygon>\n" +
        "  </gml:geometryMember>\n" +
        "</gml:MultiGeometry>\n",

        "<gml:MultiGeometry srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:geometryMember>\n" +
        "    <gml:Point srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">52,30 </gml:coordinates>\n" +
        "    </gml:Point>\n" +
        "  </gml:geometryMember>\n" +
        "  <gml:geometryMember>\n" +
        "    <gml:Polygon srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "      <gml:outerBoundaryIs>\n" +
        "        <gml:LinearRing>\n" +
        "          <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">50,31 50,29 54,29 54,31 50,31 </gml:coordinates>\n" +
        "        </gml:LinearRing>\n" +
        "      </gml:outerBoundaryIs>\n" +
        "    </gml:Polygon>\n" +
        "  </gml:geometryMember>\n" +
        "</gml:MultiGeometry>\n",

        "<gml:MultiGeometry srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:geometryMember>\n" +
        "    <gml:Point srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">2,4 </gml:coordinates>\n" +
        "    </gml:Point>\n" +
        "  </gml:geometryMember>\n" +
        "  <gml:geometryMember>\n" +
        "    <gml:LineString srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">2,3 3,4 </gml:coordinates>\n" +
        "    </gml:LineString>\n" +
        "  </gml:geometryMember>\n" +
        "</gml:MultiGeometry>\n",

        "<gml:MultiGeometry srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:geometryMember>\n" +
        "    <gml:Point srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">10,10 </gml:coordinates>\n" +
        "    </gml:Point>\n" +
        "  </gml:geometryMember>\n" +
        "  <gml:geometryMember>\n" +
        "    <gml:Point srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">30,30 </gml:coordinates>\n" +
        "    </gml:Point>\n" +
        "  </gml:geometryMember>\n" +
        "  <gml:geometryMember>\n" +
        "    <gml:LineString srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">15,15 20,20 </gml:coordinates>\n" +
        "    </gml:LineString>\n" +
        "  </gml:geometryMember>\n" +
        "</gml:MultiGeometry>\n",


        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////


        "<gml:Point srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">44,31 </gml:coordinates>\n" +
        "</gml:Point>\n",

        "<gml:LineString srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">70,38 72,48 </gml:coordinates>\n" +
        "</gml:LineString>\n",

        "<gml:LineString srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">38,48 44,41 41,36 44,31 52,18 </gml:coordinates>\n" +
        "</gml:LineString>\n",

        "<gml:Polygon srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:outerBoundaryIs>\n" +
        "    <gml:LinearRing>\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">0,0 84,0 84,48 0,48 0,0 </gml:coordinates>\n" +
        "    </gml:LinearRing>\n" +
        "  </gml:outerBoundaryIs>\n" +
        "</gml:Polygon>\n",

        "<gml:Polygon srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:outerBoundaryIs>\n" +
        "    <gml:LinearRing>\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">62,48 56,34 56,30 84,30 84,48 62,48 </gml:coordinates>\n" +
        "    </gml:LinearRing>\n" +
        "  </gml:outerBoundaryIs>\n" +
        "</gml:Polygon>\n",

        "<gml:MultiLineString srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:lineStringMember>\n" +
        "    <gml:LineString>\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">0,0 1,1 1,2 </gml:coordinates>\n" +
        "    </gml:LineString>\n" +
        "  </gml:lineStringMember>\n" +
        "  <gml:lineStringMember>\n" +
        "    <gml:LineString>\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">2,3 3,2 5,4 </gml:coordinates>\n" +
        "    </gml:LineString>\n" +
        "  </gml:lineStringMember>\n" +
        "</gml:MultiLineString>\n",

        "<gml:MultiGeometry srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:geometryMember>\n" +
        "    <gml:Point srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">64,33 </gml:coordinates>\n" +
        "    </gml:Point>\n" +
        "  </gml:geometryMember>\n" +
        "  <gml:geometryMember>\n" +
        "    <gml:Polygon srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "      <gml:outerBoundaryIs>\n" +
        "        <gml:LinearRing>\n" +
        "          <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">66,34 62,34 62,32 66,32 66,34 </gml:coordinates>\n" +
        "        </gml:LinearRing>\n" +
        "      </gml:outerBoundaryIs>\n" +
        "    </gml:Polygon>\n" +
        "  </gml:geometryMember>\n" +
        "</gml:MultiGeometry>\n",

        "<gml:Polygon srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:outerBoundaryIs>\n" +
        "    <gml:LinearRing>\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">10,10 20,15 20,20 10,20 10,10 </gml:coordinates>\n" +
        "    </gml:LinearRing>\n" +
        "  </gml:outerBoundaryIs>\n" +
        "</gml:Polygon>\n",

        "<gml:Point srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">1,2 </gml:coordinates>\n" +
        "</gml:Point>\n",

        "<gml:Point srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">176.61890298,40.3423832 </gml:coordinates>\n" +
        "</gml:Point>\n",

        "<gml:Point srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">0,0 </gml:coordinates>\n" +
        "</gml:Point>\n",

        "<gml:LineString srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">0,19 10,21 16,23 28,26 44,31 </gml:coordinates>\n" +
        "</gml:LineString>\n",

        "<gml:LineString srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">44,31 56,34 70,38 </gml:coordinates>\n" +
        "</gml:LineString>\n",

        "<gml:LineString srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">70,38 84,42 </gml:coordinates>\n" +
        "</gml:LineString>\n",

        "<gml:LineString srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">28,26 28,0 </gml:coordinates>\n" +
        "</gml:LineString>\n",

        "<gml:LineString srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">176.61751038,40.34185495 176.61890298,40.3423832 </gml:coordinates>\n" +
        "</gml:LineString>\n",

        "<gml:LineString srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">76,0 78,4 73,9 </gml:coordinates>\n" +
        "</gml:LineString>\n",

        "<gml:LineString srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">0,0 1,1 1,2 </gml:coordinates>\n" +
        "</gml:LineString>\n",

        "<gml:Polygon srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:outerBoundaryIs>\n" +
        "    <gml:LinearRing>\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">176.53050933,40.49081238 176.52605863,40.49311882 176.51930155,40.4902176 176.52235675,40.48747325 176.53050933,40.49081238 </gml:coordinates>\n" +
        "    </gml:LinearRing>\n" +
        "  </gml:outerBoundaryIs>\n" +
        "</gml:Polygon>\n",

        "<gml:Polygon srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:outerBoundaryIs>\n" +
        "    <gml:LinearRing>\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">52,18 48,6 73,9 66,23 52,18 </gml:coordinates>\n" +
        "    </gml:LinearRing>\n" +
        "  </gml:outerBoundaryIs>\n" +
        "  <gml:innerBoundaryIs>\n" +
        "    <gml:LinearRing>\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">59,18 67,18 67,13 59,13 59,18 </gml:coordinates>\n" +
        "    </gml:LinearRing>\n" +
        "  </gml:innerBoundaryIs>\n" +
        "</gml:Polygon>\n",

        "<gml:Polygon srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:outerBoundaryIs>\n" +
        "    <gml:LinearRing>\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">67,13 67,18 59,18 59,13 67,13 </gml:coordinates>\n" +
        "    </gml:LinearRing>\n" +
        "  </gml:outerBoundaryIs>\n" +
        "</gml:Polygon>\n",

        "<gml:Polygon srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:outerBoundaryIs>\n" +
        "    <gml:LinearRing>\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">0,0 4,0 4,4 0,4 0,0 </gml:coordinates>\n" +
        "    </gml:LinearRing>\n" +
        "  </gml:outerBoundaryIs>\n" +
        "  <gml:innerBoundaryIs>\n" +
        "    <gml:LinearRing>\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">1,1 1,2 2,2 2,1 1,1 </gml:coordinates>\n" +
        "    </gml:LinearRing>\n" +
        "  </gml:innerBoundaryIs>\n" +
        "</gml:Polygon>\n",

        "<gml:MultiPoint srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:pointMember>\n" +
        "    <gml:Point>\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">1,2 </gml:coordinates>\n" +
        "    </gml:Point>\n" +
        "  </gml:pointMember>\n" +
        "  <gml:pointMember>\n" +
        "    <gml:Point>\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">1,2 </gml:coordinates>\n" +
        "    </gml:Point>\n" +
        "  </gml:pointMember>\n" +
        "  <gml:pointMember>\n" +
        "    <gml:Point>\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">1,2 </gml:coordinates>\n" +
        "    </gml:Point>\n" +
        "  </gml:pointMember>\n" +
        "</gml:MultiPoint>\n",

        "<gml:MultiLineString srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:lineStringMember>\n" +
        "    <gml:LineString>\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">10,48 10,21 10,0 </gml:coordinates>\n" +
        "    </gml:LineString>\n" +
        "  </gml:lineStringMember>\n" +
        "  <gml:lineStringMember>\n" +
        "    <gml:LineString>\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">16,0 10,23 16,48 </gml:coordinates>\n" +
        "    </gml:LineString>\n" +
        "  </gml:lineStringMember>\n" +
        "</gml:MultiLineString>\n",

        "<gml:MultiPolygon srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:polygonMember>\n" +
        "    <gml:Polygon>\n" +
        "      <gml:outerBoundaryIs>\n" +
        "        <gml:LinearRing>\n" +
        "          <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">28,26 28,0 84,0 84,42 28,26 </gml:coordinates>\n" +
        "        </gml:LinearRing>\n" +
        "      </gml:outerBoundaryIs>\n" +
        "      <gml:innerBoundaryIs>\n" +
        "        <gml:LinearRing>\n" +
        "          <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">52,18 66,23 73,9 48,6 52,18 </gml:coordinates>\n" +
        "        </gml:LinearRing>\n" +
        "      </gml:innerBoundaryIs>\n" +
        "    </gml:Polygon>\n" +
        "  </gml:polygonMember>\n" +
        "  <gml:polygonMember>\n" +
        "    <gml:Polygon>\n" +
        "      <gml:outerBoundaryIs>\n" +
        "        <gml:LinearRing>\n" +
        "          <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">59,18 59,13 67,13 67,18 59,18 </gml:coordinates>\n" +
        "        </gml:LinearRing>\n" +
        "      </gml:outerBoundaryIs>\n" +
        "    </gml:Polygon>\n" +
        "  </gml:polygonMember>\n" +
        "</gml:MultiPolygon>\n",

        "<gml:MultiPolygon srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:polygonMember>\n" +
        "    <gml:Polygon>\n" +
        "      <gml:outerBoundaryIs>\n" +
        "        <gml:LinearRing>\n" +
        "          <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">24,44 22,42 24,40 24,44 </gml:coordinates>\n" +
        "        </gml:LinearRing>\n" +
        "      </gml:outerBoundaryIs>\n" +
        "    </gml:Polygon>\n" +
        "  </gml:polygonMember>\n" +
        "  <gml:polygonMember>\n" +
        "    <gml:Polygon>\n" +
        "      <gml:outerBoundaryIs>\n" +
        "        <gml:LinearRing>\n" +
        "          <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">26,44 26,40 28,42 26,44 </gml:coordinates>\n" +
        "        </gml:LinearRing>\n" +
        "      </gml:outerBoundaryIs>\n" +
        "    </gml:Polygon>\n" +
        "  </gml:polygonMember>\n" +
        "</gml:MultiPolygon>\n",

        "<gml:MultiPolygon srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:polygonMember>\n" +
        "    <gml:Polygon>\n" +
        "      <gml:outerBoundaryIs>\n" +
        "        <gml:LinearRing>\n" +
        "          <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">0,0 4,0 4,4 0,4 0,0 </gml:coordinates>\n" +
        "        </gml:LinearRing>\n" +
        "      </gml:outerBoundaryIs>\n" +
        "      <gml:innerBoundaryIs>\n" +
        "        <gml:LinearRing>\n" +
        "          <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">1,1 1,2 2,2 2,1 1,1 </gml:coordinates>\n" +
        "        </gml:LinearRing>\n" +
        "      </gml:innerBoundaryIs>\n" +
        "    </gml:Polygon>\n" +
        "  </gml:polygonMember>\n" +
        "  <gml:polygonMember>\n" +
        "    <gml:Polygon>\n" +
        "      <gml:outerBoundaryIs>\n" +
        "        <gml:LinearRing>\n" +
        "          <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">-1,-1 -2,-1 -2,-2 -1,-2 -1,-1 </gml:coordinates>\n" +
        "        </gml:LinearRing>\n" +
        "      </gml:outerBoundaryIs>\n" +
        "    </gml:Polygon>\n" +
        "  </gml:polygonMember>\n" +
        "</gml:MultiPolygon>\n",

        "<gml:MultiGeometry srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:geometryMember>\n" +
        "    <gml:Point srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">52,30 </gml:coordinates>\n" +
        "    </gml:Point>\n" +
        "  </gml:geometryMember>\n" +
        "  <gml:geometryMember>\n" +
        "    <gml:Polygon srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "      <gml:outerBoundaryIs>\n" +
        "        <gml:LinearRing>\n" +
        "          <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">50,31 50,29 54,29 54,31 50,31 </gml:coordinates>\n" +
        "        </gml:LinearRing>\n" +
        "      </gml:outerBoundaryIs>\n" +
        "    </gml:Polygon>\n" +
        "  </gml:geometryMember>\n" +
        "</gml:MultiGeometry>\n",

        "<gml:Point srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">10,10 </gml:coordinates>\n" +
        "</gml:Point>\n",

        "<gml:LineString srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">10,10 20,20 30,40 </gml:coordinates>\n" +
        "</gml:LineString>\n",

        "<gml:MultiLineString srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:lineStringMember>\n" +
        "    <gml:LineString>\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">10,10 20,20 </gml:coordinates>\n" +
        "    </gml:LineString>\n" +
        "  </gml:lineStringMember>\n" +
        "  <gml:lineStringMember>\n" +
        "    <gml:LineString>\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">15,15 30,15 </gml:coordinates>\n" +
        "    </gml:LineString>\n" +
        "  </gml:lineStringMember>\n" +
        "</gml:MultiLineString>\n",

        "<gml:MultiPolygon srsName=\"SDO:8307\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:polygonMember>\n" +
        "    <gml:Polygon>\n" +
        "      <gml:outerBoundaryIs>\n" +
        "        <gml:LinearRing>\n" +
        "          <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">10,10 20,15 20,20 10,20 10,10 </gml:coordinates>\n" +
        "        </gml:LinearRing>\n" +
        "      </gml:outerBoundaryIs>\n" +
        "    </gml:Polygon>\n" +
        "  </gml:polygonMember>\n" +
        "  <gml:polygonMember>\n" +
        "    <gml:Polygon>\n" +
        "      <gml:outerBoundaryIs>\n" +
        "        <gml:LinearRing>\n" +
        "          <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">60,60 70,70 60,70 60,60 </gml:coordinates>\n" +
        "        </gml:LinearRing>\n" +
        "      </gml:outerBoundaryIs>\n" +
        "    </gml:Polygon>\n" +
        "  </gml:polygonMember>\n" +
        "</gml:MultiPolygon>\n",

        "<gml:MultiGeometry srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:geometryMember>\n" +
        "    <gml:Point srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">2,4 </gml:coordinates>\n" +
        "    </gml:Point>\n" +
        "  </gml:geometryMember>\n" +
        "  <gml:geometryMember>\n" +
        "    <gml:LineString srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">2,3 3,4 </gml:coordinates>\n" +
        "    </gml:LineString>\n" +
        "  </gml:geometryMember>\n" +
        "</gml:MultiGeometry>\n",

        "<gml:MultiGeometry srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "  <gml:geometryMember>\n" +
        "    <gml:Point srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">10,10 </gml:coordinates>\n" +
        "    </gml:Point>\n" +
        "  </gml:geometryMember>\n" +
        "  <gml:geometryMember>\n" +
        "    <gml:Point srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">30,30 </gml:coordinates>\n" +
        "    </gml:Point>\n" +
        "  </gml:geometryMember>\n" +
        "  <gml:geometryMember>\n" +
        "    <gml:LineString srsName=\"SDO:\" xmlns:gml=\"http://www.opengis.net/gml\">\n" +
        "      <gml:coordinates decimal=\".\" cs=\",\" ts=\" \">15,15 20,20 </gml:coordinates>\n" +
        "    </gml:LineString>\n" +
        "  </gml:geometryMember>\n" +
        "</gml:MultiGeometry>\n"
      };

    for(int i = 0; i < multiGeomsGml.length; i++)
    {
      DOMParser parser = new DOMParser();
      parser.parse(
        new java.io.ByteArrayInputStream(
          multiGeomsGml[i].getBytes()));
      XMLDocument doc = parser.getDocument();

      Node multiGeoms = doc.getFirstChild();
      JGeometry geom = GML.fromNodeToGeometry(multiGeoms);
      System.out.println(geom);
    }
  }
}
