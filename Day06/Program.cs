PartOne();
PartTwo();

void PartOne()
{
    FindByDistinct(4);
}

void PartTwo()
{
    FindByDistinct(14);
}

void FindByDistinct(int limit)
{
    var line =
        "rvnvzvhzzjgjgffclllnhhtltptgptgpttjhttsllmbbphbpbzpbpjjcwjwqwccnrrtvrtrfrwffnqffsggwzzhtzhthqhffmrrzsrrnrtrqqbllhrlrjrvvrvvgdgjgfjjtzznffrfvfggswgssccpcwpccstcsstwssgzssswsgwsgsnsshcsscsffcwcmmhmsmrsrddwhhszsfsjfsfccwssvdssmzzwrzzjfzzvzzfsfsvshschhvlhhvmvpvhhstsdtstgtrrtjjcssgfssnsnfsnscnsslvvqbbhthqtqzqmzmjjfmmbdmmzdmdpmpnnfjnnrwnwbwrrwjrrttfzzlwwfmmnhhqlhqqbnqnqznncmmhfmfftsfszssftstggppfddtztltctqcqjcqcmclcnccdgcggvmvvcsstztbzttsccmgcghcczfzszbzmbmjjggsqgghbhjjhhrrjljmllczlzzqssjfjqfjfmfdfgffczfzwwpfwpwbbftbffplphhfcftctlcclhlnlhnhlhnhqnhhjbjmmtpmmlsmllvhhjghhmzzwpzprrjrzzvrvcvqvssgssnccmgmppfhfwhhczhhprhrffpvvqrqvqccdhdvvvssvdvwdwwzggfvfnvvqvwwzwmzzvttgzzwjjfvvpvffqpqhqrrwccjbjppbzbrbrrphrhgrhhzbbhrrblbjjznnlccsffpcfpcfpfddfwddbffczztzsttzsstddrqdqqchqccrlccfcwwghwhnhbhjbhhzrrgprrftrffqlljlslggzdzvvrgvgcgnnngtnggdcgddhjhchqcqfqwfwjffqppblbddgmdgmddrnddjtdjttgzgpzggwvwjvwwhdwwbvvtftcfttpftpfpzfznnchnhrrdtdbtdbdppsjsgsttptsptssnwntwnnsshqqgnnqnddhjjtqqjhhmghmhmsstrrhmmwvvlssprsrbbswsddbnntmtbmtbmmtmrrffvjffdrffnttbffbccgchghjgjwwshwswdswdsdsrdsdjdvjjgbjbssptpddzbdddqdpdspswssjrjwwcbbvsspnspslpplzlqlccvlvfllntlntnqnrqnqpqlqflfrfsfgsfswwptwwgqggrhghzghhrthtzhzsswhhzffpsffhnnrvnrvvhmmlvvqsslddhcddsllpmpggrhrcrbbmnmjmqmlmpmrrqwqhqrqhrrgrqqsrrpjpdjppzhphthddlzdzhddjvdjdcjcncnvnzzvwzvzgzjggcllvpllgdgqqdvvwnvwvwqqvwvvrbbtqqwhdztqfzzcqrshjzwqnpdsshmpjzwqdptbvfqzmfnbtlgbbsjbqgnblhbbpsfdzvcmpzfwczcnbdndsjzccjcqnrdglwfrvwtnjwpvpvvgwtmnpzhbwnbqwznmdvdrsjnlsfrpcnhlbmlgmrcjbbvhqnvbrmlnfttjllstqnqqnhqrzrhfqjbfbwfhhjzwtwzjmszzhjnjbhrlbnnpfvdmlftjnfsfnvddqfhqqlljrthptvmhbqrdmdcmljwgbrqrjwcrtmvjgqtblnslgbjmdsrrpgfsctrhwlwnszpljhrfnsfpcsgczzltgsztclhgcqljrcmbbpdlztncnrnrmgrttplcnldfqddqhznmcczbmwvsztmwmcqnrzmlmqchnhnhrrhhfntjzqcbnttspptqwvphlbtpfcbhdqzbhsbvhmsqbsdntwpcrnzvmbgqsgttbqhhblfjpmvfcrzhfnzwrzbzgsdfqndzzhfdnrvsnvfbptthjnhgljhrvwwrlbnfpvvjdjchcgbhfrqvszhrhqvtzplwsptvdhqwlzhcjpclmmrlccvgvtgsfpnjhqhrbqglznpdhmsqwwsbmhmlsmmvvghsmplqjchrfctltmnqnddzqjfpljwljbdqjcqdqzwsbcclqsmsmlstvljwwtfmpnhqzqfjghjfchjccqrchsvngvrnwfwttsnvrdlfvwfptsjcpslvvpmjclfcpljqjszptsgsmntzrdjbgrzmgvzddqrlsndjzzqbznqnphbnwfhtjjlwjpsvffrdrbsbttpgrvmqrdndqvlgzcpfbttvqdgvrmtvfclcbcwllthmdzjcflwpnrsqzrjdzbvqgzsqvjjpjjpnjtcjqhcfbjdqndlcwzhcbjtgtlvtdwctdnqcbcgsmrcrmwjntdwbjdbzmshbvlspjfdbvmlrbdzlmlggthvphnrqlrcdsqpsgqcmpgmgdzvdqlmcldvztpsbmpwjgjfhswplwrvwpbwbsgsvlhdvmpzwnnbwjwmshwcnqfqjdpchfjjcbdnslqchhnznpqpnnctznbtccclgjhmnngdjlmqnzpsdptqqcrblmrlnnpgvrfrtmbjnmspfrbwpclhgtbsghndrjfbggsplvcjnhjjbqzsfdpfnvchzjgbhdqgddfgddvzdcrjlntnsmscqwmpptqgbnvtsvpjvmhcfpbfrpzqbpfhlbjrmbmvdvvnvfqsndglvhfrqcsbsbbprscrbfthzcwcdrprqrwjzwrpblfllpwzlhmqvltjgpcjzpzwbltgwsrgrrhzcqfpvhcprdhnzcfphqrwcvtpcbppjwzmmwjhbvwbblnbwvcqzvlfzjhgmlnhlhrbsplfctggfbhbgwpncznvtmdtqqmjsvsnrlqswzvflrfsncgpdcndlwrfrqwqnqtjmsphwsgzhdjpnsdgrbrfhbfdrntwvgvbwnvwnrmdbhqgrglbfwprflnrljrwsgwtpgtmfhvvghtzndvwlzjchhmlwcncmpvrslrglzjcnhfdqhcrljhgbzpssvdnmfwzstmvrztgpsscfswltnbwrrtcnvbswmmjbmnnnvqwjzhprfnvlbvzzdvbwlwchrvqnwwpbnttbhfdvjjvzsznhczjcncmcrmwtrlsvbwpsrcwqdvgcfjsbqnwmjmtcgpnmcbfbcqhzrjbtlpvwzhjqqprbdnbgzfwlprlcspwjwnfftldqzbcgqnjtglvbpqffdvjbpslqcdzwdnmncvcwfshdhsmssttqfrsbnjgmhfqzlgrbpdfqtfdwslsgphfzzgbzjssfbgnwztzmczplqwjmhtlflpvqqqmrvlllhngtfgsvbbnvhzqbcgpmnlsmpwqwgqfjpzplzjhrslwzrsrgjgpppjlnhrnggcdzvspsztnschnqftgffbtvrpzndzpqmtsfmwgnrvpmtgpvnmqfmwgcvlznwqnjnjwpgnqfjwtdhhmztlvlcvrlzmlpmjdvdnzwbfsshfsvbbhqsmphjhqtlnvlsmvwlqvfqpnjnzlgmdvwzzrllmcgwtqdwphhbwmlrqhqrfmdvtqswvsllqvwmfbbpllsbjbvgsmrcgqvfgsnszfrdlcjbtfgcbclhmzlmqlnhmslcmgrcvjjlbpsjjcznzqwmztcgdgbmrlgwzjzzjrpndfrdzztzzgmsrcnwrvqrdcczrbhdpfjwvqsmbrcvllvjrrbrsqnzldltdgzscjrssvdhzhnvltpgfdfcvfbtqmphdzhpzgjhjbwsmdlbqqgcrhjrwhgvfgdllmmlnpsbtvdrrzmltfwgrcsfrrsdbdmjtrwhnlgcrgjgmbzvzvqbflvbrsqcssjgsvpjmlhtcggzwbvddmwwtfdrlltjqcpwnthczzlzdszvtmrmhbpcgstvrsnmbdcmjzsvnncmgmlnrzzhfvmblgptwwwbrmtcczjwcqmvdrsvfjgqqvghnhbntqcdrppfmvdzbcjvztrnpdhmdpmnvsnzzldvdfqbdrwqqqqsmswthwpjwdrflszbspqhpfwztjjcbdsrftdsrsfdltnfztcslmbsghgrtcscrfmptqplwpmtqdzthgfjhbqdnsffrpjmgczmrlfvzcjttwtmtqfbtlqrttvjdwhfgcgcclrlswmzhzbfhjrggnhwtnffnqqcvldlttvvgrbcqbmqzvtflfmdblhdbzphrqtbshvp";
    var queue = new Queue<char>();

    for (var index = 0; index < line.Length; index++)
    {
        var c = line[index];

        queue.Enqueue(c);

        if (queue.Count != limit)
        {
            continue;
        }

        if (queue.Distinct().Count() == limit)
        {
            Console.WriteLine(index + 1);
            break;
        }

        queue.Dequeue();
    }
}
