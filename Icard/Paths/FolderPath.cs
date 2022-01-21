using System;
using System.Collections.Generic;
using System.Text;

namespace Icard.Paths
{
    internal static class FolderPath
    {
        internal static string Folder_Path = @"C:\Users\Ivan\OneDrive\Desktop\Folder";

        internal static string SENDER_ADDRESS = @"[A-Z]{4}[A-Z]{2}[0-9A-Z]{2}[0-9A-Z][0-9A-Z]{3}";

        internal static string INPUT_PATTERN = @"({2:)(I[0-9]{3})([A-Z]{8})([X])([A-Z]{3})([S|N|U])([1|2|3])(003|020})";

        internal static string OUTPUT_PATTERN = @"({2:)(O)([0-9]{3})([0-9]{4})([0-9A-Z]{28})([0-9]{6})([0-9]{4})([S|N|U]})";

        internal static string BASIC_HEADER_PATTERN = @"({1:)([FAL])(01|21)([A-Z]{8}[^X][A-Z]{3})([0-9]{4})([0-9]{6}})";

        internal static string USER_HEADER_REGEX = @"{3:({103:)|([A-Z]{3}})|({119:)(STP})|({113:)([A-Za-z]{4}})|({108:)([A-Z0-9]{16}})|({115:)([A-Z0-9]{30}})";

        internal static string PATTER_BLOCK_ID = @"({1:|{2:|{3:|{4:|{5:)";

        internal static string BLOCK_ID_1 = "{1:";

        internal static string BLOCK_ID_2 = "{2:";

        internal static string BLOCK_ID_3 = "{3:";

        internal static string FILED_FILE_CANNOT_USE_TWICE = "!!!WARNING CANNOT USE SAME FILE \"{0}\" TWICE !!!";

        internal static string FILE_FILED = "File \"{0}\" is failed and move to Folder -> FAILED";

        internal static string FILE_SUCCESS = "File \"{0}\" is success and moved to Folder -> SUCCESS";

        internal static string SUCCESS_FOLDER_PATH = @"C:\Users\Ivan\OneDrive\Desktop\Folder\SUCCESS\{0}";
                                                      

        internal static string FILED_FOLDER_PATH = @"C:\Users\Ivan\OneDrive\Desktop\Folder\FAILED\{0}";

        internal static string FILE_DESTINATION = @"C:\Users\Ivan\OneDrive\Desktop\Folder\{0}";

        internal static string SWIFT_FORMAT_FIELDS = ":20:|:13C:|:23B:|:23E:|:26T:|:32A:|:33B:|:36:|:50a:|:50K:|:51:|:52A:|:53A:|:54A:|:55A:|:56A:|:57A:|:59A:|:59:|:70:|:71A:|:71F:|:71G:|:72:|:77B:|NAME|ADDRESS|";
    };



}

