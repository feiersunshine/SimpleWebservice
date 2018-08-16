using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication
{
	/// <summary>
	/// WebService 的摘要说明
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
	// [System.Web.Script.Services.ScriptService]
	public partial class WebService : System.Web.Services.WebService
	{

		[WebMethod]
		public string HelloWorld()
		{
			return "Hello World";
		}
		/// <summary>
		/// 根据PID获取DetailCharge对象集合
		/// </summary>
		/// <param name="pid">病人ID</param>
		/// <returns>返回对象的集合</returns>
		[WebMethod]
		public List<DetailCharge> GetDetailChargeByPid(string pid)
		{
			//拼接sql连接字符串
			string connStr = "Data Source=172.16.20.21;Initial Catalog=chisdb_dev;User ID=sa;Password=Founder123";
			//实例化对象的集合
			List<DetailCharge> chargeList = new List<DetailCharge>();
			//数据库连接 using自动化内存释放
			//1.sqlconnection数据库连接实例化 
			using (SqlConnection conn = new SqlConnection(connStr))
			{
				//2.连接通道打开
				conn.Open();
				//3.创建命令行
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = string.Format(@"SELECT TOP 5
								        patient_id ,
								        admiss_times ,
								        ledger_sn ,
								        detail_sn ,
								        occ_time
										FROM    dbo.zy_detail_charge WITH (NOLOCK)
										WHERE   patient_id = '{0}'", pid);

					//4.sqldatareader逐行读取数据
					SqlDataReader sr = cmd.ExecuteReader();
					while (sr.Read())
					{
						chargeList.Add(new DetailCharge()
						{
							admiss_times = sr.GetValue(1).ToString(),
							detail_sn = sr.GetValue(2).ToString(),
							ledger_sn = sr.GetValue(3).ToString(),
							occ_time = sr.GetValue(4).ToString(),
							patient_id = sr.GetValue(0).ToString()

						});
					}
				}
			}
			return chargeList;
		}


		/// <summary>
		/// 根据PID获取DetailCharge对象集合
		/// </summary>
		/// <param name="pid">病人ID</param>
		/// <returns>返回对象的集合</returns>
		[WebMethod]
		public List<PatientMi> GetPatientMiByPid(string pid)
		{
			//拼接sql连接字符串
			string connStr = "Data Source=172.16.20.21;Initial Catalog=chisdb_dev;User ID=sa;Password=Founder123";
			//实例化对象的集合
			List<PatientMi> chargeList = new List<PatientMi>();
			//数据库连接 using自动化内存释放
			//1.sqlconnection数据库连接实例化 
			using (SqlConnection conn = new SqlConnection(connStr))
			{
				//2.连接通道打开
				conn.Open();
				//3.创建命令行
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = string.Format(@"SELECT TOP 5
												        patient_id ,
												        inpatient_no ,
												        outpatient_no ,
												        name ,
												        birth_date 
												FROM    dbo.a_patient_mi WITH ( NOLOCK )
										WHERE   patient_id = '{0}'", pid);

					//4.sqldatareader逐行读取数据
					SqlDataReader sr = cmd.ExecuteReader();
					while (sr.Read())
					{
						chargeList.Add(new PatientMi()
						{
							patient_id = sr.GetValue(0).ToString(),
							inpatient_no = sr.GetValue(1).ToString(),
							outpatient_no = sr.GetValue(2).ToString(),
							name = sr.GetValue(3).ToString(),
							birth_date = sr.GetValue(4).ToString()
						});
					}
				}
			}
			return chargeList;
		}
		public class PatientMi
		{
			public string patient_id { get; set; }
			public string inpatient_no { get; set; }
			public string outpatient_no { get; set; }
			public string name { get; set; }
			public string birth_date { get; set; }
			public string sex { get; set; }
			public string marry_code { get; set; }
			public string nation_code { get; set; }
			public string occupation_code { get; set; }
			public string vip_code { get; set; }
			public string social_no { get; set; }
			public string home_tel { get; set; }
			public string home_street { get; set; }
			public string home_district { get; set; }
			public string home_zipcode { get; set; }
			public string temp_street { get; set; }
			public string temp_zipcode { get; set; }
			public string employer_name { get; set; }
			public string employer_street { get; set; }
			public string employer_district { get; set; }
			public string employer_tel { get; set; }
			public string employer_zipcode { get; set; }
			public string relation_name { get; set; }
			public string relation_code { get; set; }
			public string relation_street { get; set; }
			public string relation_district { get; set; }
			public string relation_tel { get; set; }
			public string temp_tel { get; set; }
			public string contract_code { get; set; }
			public string insur1_code { get; set; }
			public string insur2_code { get; set; }
			public string lastvisit_date { get; set; }
			public string lastadmiss_times { get; set; }
			public string lastbill_acc { get; set; }
			public string baddebit_acc { get; set; }
			public string baddebit_date { get; set; }
			public string total_insu_acc { get; set; }
			public string birth_place { get; set; }
			public string country { get; set; }
			public string temp_district { get; set; }
			public string fv_dept { get; set; }
			public string fv_date { get; set; }
			public string hic_no { get; set; }
			public string py_code { get; set; }
			public string cpy { get; set; }
			public string blood_type { get; set; }
			public string RH_blood { get; set; }
			public string base_insure_no { get; set; }
			public string other_insure_no { get; set; }
			public string modi_op_id { get; set; }
			public string modi_date { get; set; }
			public string now_district { get; set; }
			public string now_street { get; set; }
			public string social_no2 { get; set; }
			public string health_ID { get; set; }
			public string native { get; set; }
			public string patient_email { get; set; }
			public string qq { get; set; }
			public string social_no3 { get; set; }
			public string relation_code2 { get; set; }
			public string temp_diag { get; set; }
			public string patCase_status { get; set; }
			public string born_hospital { get; set; }
			public string enter_opera { get; set; }
			public string create_date { get; set; }
			public string empi_id { get; set; }
		}
		public class DetailCharge
		{
			public string patient_id { get; set; }
			public string admiss_times { get; set; }
			public string ledger_sn { get; set; }
			public string detail_sn { get; set; }
			public string occ_time { get; set; }

		}
		[WebMethod]
		public string Cal(int no1, int no2)
		{
			return (no1 + no2).ToString();
		}
	}
}
